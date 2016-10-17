using MultiscaleModelling.Model;
using MultiscaleModelling.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MultiscaleModelling.Utilities.CAMethods;

namespace MultiscaleModelling
{
    public partial class MainForm : Form
    {
        private string [] Methods = { @"von Neumann", @"Moore", @"Random Hexagonal", @"Random Pentagonal" };
        private Board board = new Board();
        private bool run = true;
        private Graphics g=null;
        public MainForm()
        {
            InitializeComponent();
            methods.DropDownStyle = ComboBoxStyle.DropDownList;
            methods.DataSource = Methods;
        }
        private async void stop_Click(object sender, EventArgs e)
        {
            pause_Click(null, null);
            Thread.Sleep(200);
            g = g ?? panel.CreateGraphics(); 
            g.Clear(Color.White);
            board.GetBoard().Clear();
            board.Colors.Clear();
        }


        private async void pause_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { run = false; });
        }

        private async void start_Click(object sender, EventArgs e)
        {
            if (board.GetBoard().Count == 0)
            {
                ShowError("You don't have any Cells added!");
                return;
            }
            methods.Enabled = false;
            periodic.Enabled = false;
            textBox1.Enabled = false;
            Methods m = methods.Text.TranslateComboBox();
            await Task.Run(() => StartCounting(m));
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }

        private void StartCounting(CAMethods.Methods m)
        {
            run = true;
            while (run)
            {
                CAMethods.CountNextStep(m, periodic.Checked);
                g = g ?? panel.CreateGraphics();
                g.DrawBoard();
                if (board.GetBoard().Count > board.SizeX * board.SizeY)
                    run = false;
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            if (run)
            {
                run = false;
                ShowError("You must pause before adding new cells");
                return;
            }
            MouseEventArgs args = (MouseEventArgs)e;
            Coordinate coord = new Coordinate(args.X, args.Y);
            Cell cell = new Cell(board.NumberOfGroups+1);
            board.AddToBoard(cell, coord);
            g = g ?? panel.CreateGraphics();        
            g.DrawCell(board.GetBoard()[coord], coord);
        }
        

        private void generate_Click(object sender, EventArgs e)
        {
            int value;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ShowError("The field for number of cells cannot be empty!");
                return;
            }
            if(!int.TryParse(textBox1.Text, out value))
            {
                ShowError("The field for number of cells must be a number!");
                return;
            }
            CAMethods.CreateRandomCells(value);
            g = g ?? panel.CreateGraphics();
            lock (g)
            {
                g.DrawBoard();
            }
        }
    }
}
