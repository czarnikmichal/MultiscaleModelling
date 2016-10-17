using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Board
    {
        private static int _sizeX = 0;
        private static int _sizeY = 0;
        private static Dictionary<Coordinate, Cell> _board = null;
        private static int _numberOfGroups = 0;
        public int NumberOfGroups
        {
            get
            {
                return _numberOfGroups;
            }
            private set
            {
                _numberOfGroups = value;
            }
        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }
            set
            {
                _sizeX = value;
            }
        }
        public int SizeY
        {
            get
            {
                return _sizeY;
            }
            set
            {
                _sizeY = value;
            }
        }
        public Board()
        {
            _board = _board ?? new Dictionary<Coordinate, Cell>();
        }
        
        public Dictionary<Coordinate, Cell> GetBoard()
        {
            return _board;
        }

        public bool AddToBoard(Cell c, Coordinate coord)
        {
            if (coord.CoordinateX >= _sizeX || coord.CoordinateY >= _sizeY)
                throw new IndexOutOfRangeException();
            if (_board.ContainsKey(coord))
                return false;
            _board.Add(coord, c);
            if (c.GroupID > NumberOfGroups)
                NumberOfGroups = c.GroupID;
            return true;
        }

    }
}
