using MultiscaleModelling.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Utilities
{
    class Drawer
    {
        private Bitmap _bmp;
        private Bitmap bmp
        {
            get
            {
                return _bmp;
            }
            set
            {
                _bmp = value;
                MakeItWhite();
            }
        }
        public int SizeX
        {
            get
            {
                return bmp.Width;
            }
            set
            {
                bmp = new Bitmap(value, bmp.Height);
            }
        }

        public int SizeY
        {
            get
            {
                return bmp.Height;
            }
            set
            {
                bmp = new Bitmap(bmp.Width, value);
            }
        }
        public Drawer(int sizeX, int sizeY)
        {
            bmp = new Bitmap(sizeX, sizeY);
        }

        public void MakeItWhite()
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    bmp.SetPixel(j, i, Color.White);
                }
            }
        }

        public void DrawBoard(Graphics g, Board1 b)
        {
            if (SizeX == b.board.GetLength(0) || SizeY == b.board.GetLength(1))
            {
                for (int i = 0; i < b.board.GetLength(0); i++)
                {
                    for (int j = 0; j < b.board.GetLength(1); j++)
                    {
                        bmp.SetPixel(i, j, b.GetColor(b.board[i, j]));
                    }
                }
            }
            g.DrawImage(bmp, 0, 0);
        }
        public void DrawCells(Graphics g, Board1 b)
        {
            foreach (Coordinate c in b.NewlyAdded)
            {
                bmp.SetPixel(c.CoordinateX, c.CoordinateY, b.GetColor(b.board[c.CoordinateX, c.CoordinateY]));
            }
            g.DrawImage(bmp, 0, 0);
        }
    }
}
