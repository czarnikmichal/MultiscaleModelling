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
        private bool run = false;
        private Graphics g=null;
        public MainForm()
        {
            InitializeComponent();
            methods.DropDownStyle = ComboBoxStyle.DropDownList;
            methods.DataSource = Methods;
            panelX.Text = panel.Width.ToString();
            panelY.Text = panel.Height.ToString();
        }
        private async void stop_Click(object sender, EventArgs e)
        {
            pause_Click(null, null);
            Thread.Sleep(200);
            g = g ?? panel.CreateGraphics(); 
            g.Clear(Color.White);
            board.GetBoard().Clear();
            board.Colors.Clear();
            methods.Enabled = true;
            periodic.Enabled = true;
            textBox1.Enabled = true;
        }


        private async void pause_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { run = false; });
            textBox1.Enabled = true;
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
            if (args.Button == MouseButtons.Left)
            {
                Cell cell = new Cell(board.NumberOfGroups + 1);
                board.AddToBoard(cell, coord);
                g = g ?? panel.CreateGraphics();
                g.DrawCell(board.GetBoard()[coord], coord);
            }
            else
            {
                DrawNewInclusion(coord);
            }
        }

        private void DrawNewInclusion(Coordinate coord)
        {
            if (squareIncl.Checked)
            {
                int x = ShowErrorForParsing("for length of square", textBox2);
                int y = ShowErrorForParsing("for height of square", textBox3);
                CreateSquareInclusion(coord, x, y);
            }
            else
            {
                int radius = ShowErrorForParsing("for radius of circle", textBox2);
                CreateCirlceInclusion(coord, radius);
            }
        }

        private void CreateCirlceInclusion(Coordinate coord, int radius)
        {
            for (int x = coord.CoordinateX - radius; x <= coord.CoordinateX; x++)
            {
                for (int y = coord.CoordinateY - radius; y <= coord.CoordinateY; y++)
                {
                    if ((x - coord.CoordinateX) * (x - coord.CoordinateX) + (y - coord.CoordinateY) * (y - coord.CoordinateY) <= radius * radius)
                    {
                        int x2 = coord.CoordinateX - (x - coord.CoordinateX);
                        int y2 = coord.CoordinateY - (y - coord.CoordinateY);
                        board.AddIOnclusionToBoard(new Cell(), new Coordinate(x, y), periodic.Checked);
                        board.AddIOnclusionToBoard(new Cell(), new Coordinate(x2, y2), periodic.Checked);
                        board.AddIOnclusionToBoard(new Cell(), new Coordinate(x, y2), periodic.Checked);
                        board.AddIOnclusionToBoard(new Cell(), new Coordinate(x2, y), periodic.Checked);
                    }
                }
            }
            g = g ?? panel.CreateGraphics();
            g.DrawBoard();
        }

        private void CreateSquareInclusion(Coordinate coord, int x, int y)
        {
            for (int i = coord.CoordinateX - x/2; i < coord.CoordinateX + x/2; i++)
            {
                for (int j = coord.CoordinateY - y/2; j < coord.CoordinateY/2 + y; j++)
                {
                    board.AddIOnclusionToBoard(new Cell(), new Coordinate(i, j), periodic.Checked);
                }
            }
            g = g ?? panel.CreateGraphics();
            g.DrawBoard();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            int value = ShowErrorForParsing("for number of cells", textBox1);
            if (value > 0)
            {
                CAMethods.CreateRandomCells(value);
                g = g ?? panel.CreateGraphics();
                lock (g)
                {
                    g.DrawBoard();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void squareIncl_Click(object sender, EventArgs e)
        {
            circleIncl.Checked = !circleIncl.Checked;
            if (circleIncl.Checked)
            {
                textBox3.Visible = false;
            }
            else
            {
                textBox3.Visible = true;
            }
        }

        private void circleIncl_Click(object sender, EventArgs e)
        {
            squareIncl.Checked = !squareIncl.Checked;
            if (circleIncl.Checked)
            {
                textBox3.Visible = false;
            }
            else {
                textBox3.Visible = true;
            }

        }

        public int ShowErrorForParsing(string fieldName, TextBox tb)
        {
            int value;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                ShowError("The field " + fieldName + " cannot be empty!");
                return -1;
            }
            if (!int.TryParse(tb.Text, out value))
            {
                ShowError("The field "+ fieldName+" must be a number!");
                return -1;
            }
            return value;
        }

        private void panelX_TextChanged(object sender, EventArgs e)
        {
            int value = ShowErrorForParsing("for X diemension", panelX);
            board.GetBoard().Clear();
            board.Colors.Clear();
            g = g ?? panel.CreateGraphics();
            g.Clear(Color.White);
            if (value == -1)
            {
                value = 400;
            }

            panel.Width = value;
            start.Location = new Point(20 + value, start.Location.Y);
            stop.Location = new Point(20 + value, stop.Location.Y);
            generate.Location = new Point(20 + value, generate.Location.Y);
            pause.Location = new Point(20 + value, pause.Location.Y);
            periodic.Location = new Point(20 + value, periodic.Location.Y);
            circleIncl.Location = new Point(20 + value, circleIncl.Location.Y);
            squareIncl.Location = new Point(20 + value, squareIncl.Location.Y);
            textBox1.Location = new Point(20 + value, textBox1.Location.Y);
            textBox2.Location = new Point(20 + value, textBox2.Location.Y);
            textBox3.Location = new Point(20 + value, textBox3.Location.Y);
            methods.Location = new Point(20 + value, methods.Location.Y);
            board.SizeX = value;
            this.Width = 200 + value;
           
        }

        private void panelY_TextChanged(object sender, EventArgs e)
        {
            int value = ShowErrorForParsing("for Y diemension", panelY);
            board.GetBoard().Clear();
            board.Colors.Clear();
            g = g ?? panel.CreateGraphics();
            g.Clear(Color.White);
            if (value == -1)
            {
                value = 400;
            }
            panel.Height = value;
            if(value>400)
                this.Height = 80 + value;
            board.SizeY = value;

        }
    }
}
