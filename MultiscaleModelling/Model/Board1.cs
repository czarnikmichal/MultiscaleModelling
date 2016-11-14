using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Board1
    {
        private Random rand = new Random();
        public int[,] board;
        private int _numOfGroups;
        private Dictionary<int, Color> _colorMap;
        public List<Coordinate> NewlyAdded
        {
            get;
            private set;
        }
        private bool _isPeriodic;
        public int NumberOfGroups
        {
            get
            {
                return _numOfGroups;
            }
            private set
            {
                _numOfGroups = value;
            }
        }
        public int SizeX
        {
            get
            {
                return board.GetLength(0);
            }
            set
            {
                board = new int[value, board.GetLength(1)];
            }
        }

        public int SizeY
        {
            get
            {
                return board.GetLength(1);
            }
            set
            {
                board = new int[board.GetLength(0), value];
            }
        }
        public Board1()
        {
            _isPeriodic = false;
            board = new int[400, 400]; 
            _colorMap = new Dictionary<int, Color>();
            //Empty Field
            _colorMap.Add(0, Color.White);
            //Inclusion Field
            _colorMap.Add(-1, Color.Black);
            NewlyAdded = new List<Coordinate>();
        }

        public Color GetColor(int grpNumber)
        {
            if (!_colorMap.ContainsKey(grpNumber))
            {
                int R = rand.Next(2, 253);
                int G = rand.Next(2, 253);
                int B = rand.Next(2, 253);
                Color newColor = Color.FromArgb(R, G, B);
                _colorMap.Add(grpNumber, newColor);
                return newColor;
            }
            return _colorMap[grpNumber];
        }

        public bool AddCell(int x, int y)
        {
            _numOfGroups = _numOfGroups + 1;
            return AddCell(x, y, _numOfGroups);
        }

        public bool AddCell(int x, int y, int grp)
        {
            NewlyAdded.Add(new Coordinate(x, y));
            return (AddCell(x, y, grp, false));
        }

        private bool AddCell(int x, int y, int grp, bool canOverride)
        {
            if (_isPeriodic)
            {
                x = x % board.GetLength(0);
                y = y % board.GetLength(0);
            }
            if (x > 0 || x <= board.GetLength(0) || y > 0 || y <= board.GetLength(1))
            {
                if (canOverride)
                {
                    board[x, y] = grp;
                    return true;
                }
                if (board[x, y] == 0)
                {
                    board[x, y] = grp;
                    return true;
                }
            }
            return false;
        }
        
        public void AddInclusionCell(int x, int y)
        {
            if (!AddCell(x, y, -1, true))
            {
                throw new IndexOutOfRangeException("The x or y coordinate are out range. X=" + x + ", Y=" + y + ".\nMax size X=" + board.GetLength(0) + ", Y=" + board.GetLength(1));
            }
        }   
    }
}
