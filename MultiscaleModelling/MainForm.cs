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

namespace MultiscaleModelling
{
    public partial class MainForm : Form
    {
        private string [] Methods = { @"von Neumann", @"Moore", @"Random Hexagonal", @"Random Pentagonal", @"Moore Rules" };
        private bool run = false;
        private bool finish = false;
        private Graphics g=null;
        private Drawer drawer;
        CAMethods1 cM;
        public MainForm()
        {
            InitializeComponent();
            drawer = new Drawer(panel.Width, panel.Height);
            cM = new CAMethods1();
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
            cM.ClearBoard();
            drawer.MakeItWhite();
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
            if (cM.board.NewlyAdded.Count == 0 && !finish)
            {
                ShowError("You don't have any Cells added!");
                return;
            }
            if (cM.board.NewlyAdded.Count == 0 && finish)
            {
                ShowError("You have to clean board by clicking stop!");
                return;
            }
            methods.Enabled = false;
            periodic.Enabled = false;
            textBox1.Enabled = false;
            cM.BoundaryMethod = cM.TranslateComboBox(methods.Text);
            await Task.Run(() => StartCounting());
            
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK);
        }

        private void StartCounting()
        {
            g = g ?? panel.CreateGraphics();
            run = true;
            while (run)
            {
                if (cM.board.NewlyAdded.Count == 0)
                {
                    if (cM.ShouldEnd())
                    {
                        run = false;
                        finish = true;
                    }
                }
                cM.Count();
                drawer.DrawCells(g, cM.board);
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            g = g ?? panel.CreateGraphics();
            if (run)
            {
                run = false;
                ShowError("You must pause before adding new cells");
                return;
            }
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Left)
            {
                cM.AddNewCell(args.X, args.Y);
                drawer.DrawCells(g, cM.board);

            }
            else
            {
                DrawNewInclusion(args.X, args.Y);
                drawer.DrawBoard(g, cM.board);
            }
        }

        private void DrawNewInclusion(int xCoord, int yCoord)
        {
            if (squareIncl.Checked)
            {
                int x = ShowErrorForParsing("for length of square", textBox2);
                int y = ShowErrorForParsing("for height of square", textBox3);
                cM.CreateRectangleInclusion(xCoord, yCoord, x, y);
            }
            else
            {
                int radius = ShowErrorForParsing("for radius of circle", textBox2);
                cM.CreateCircularInclusion(xCoord,yCoord, radius);
            }
        }

        private void generate_Click(object sender, EventArgs e)
        {
            g = g ?? panel.CreateGraphics();
            int value = ShowErrorForParsing("for number of cells", textBox1);
            if (value > 0)
            {
                cM.AddRandomCells(value);
                drawer.DrawCells(g, cM.board);
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
            cM.ClearBoard();
            drawer.MakeItWhite();
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

            g = panel.CreateGraphics();
            g.Clear(Color.White);
            cM.board.SizeX = value;
            drawer.SizeX = value;
            this.Width = 200 + value;
           
        }

        private void panelY_TextChanged(object sender, EventArgs e)
        {
            int value = ShowErrorForParsing("for Y diemension", panelY);
            cM.ClearBoard();
            drawer.MakeItWhite();
            g = g ?? panel.CreateGraphics();
            g.Clear(Color.White);
            if (value == -1)
            {
                value = 400;
            }
            panel.Height = value;
            g = panel.CreateGraphics();
            g.Clear(Color.White);
            cM.board.SizeY = value;
            drawer.SizeY = value;
            if (value>400)
                this.Height = 80 + value;
        }

        private void periodic_CheckedChanged(object sender, EventArgs e)
        {
            cM.IsPeriodic = periodic.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addIncl_Click(object sender, EventArgs e)
        {
            if (finish)
            {
                if (squareIncl.Checked)
                {
                    int x = ShowErrorForParsing("for length of square", textBox2);
                    int y = ShowErrorForParsing("for height of square", textBox3);
                    int number = ShowErrorForParsing("for number of inclusions", incNumber);
                    cM.AddSquareInclusions(number, x,y);
                }
                else
                {
                    int radius = ShowErrorForParsing("for radius of circle", textBox2);
                    int number = ShowErrorForParsing("for number of inclusions", incNumber);
                    cM.AddCircleInclusions(number, radius);
                }
            }
            else
            {
                ShowError("You can't add cells to boundries before counting is over!");
                return;
            }
            drawer.DrawBoard(g,cM.board);
        }
    }
}
