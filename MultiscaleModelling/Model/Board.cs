﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Board
    {
        private static Random rand = new Random();
        private static int _sizeX = 400;
        private static int _sizeY = 400;
        private static Dictionary<Coordinate, Cell> _board = null;
        private static Dictionary<int, Pen> _colors = new Dictionary<int, Pen>();
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

        public Dictionary<int, Pen> Colors
        {
            get
            {
                return _colors;
            }
            private set
            {
                _colors = value;
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
            return AddToBoard(c, coord, false);
        }

        public bool AddToBoard(Cell c, Coordinate coord, bool periodic)
        {
            if (coord.CoordinateX >= _sizeX || coord.CoordinateY >= _sizeY)
            {
                if (!periodic)
                {
                    return false;
                }
                coord.CoordinateX = coord.CoordinateX % _sizeX;
                coord.CoordinateY = coord.CoordinateY % _sizeY;
            }
            if (_board.ContainsKey(coord))
                return false;
            _board.Add(coord, c);
            if (c.GroupID > NumberOfGroups)
            {
                int r = rand.Next() % 255;
                int g = rand.Next() % 255;
                int b = rand.Next() % 255;
                NumberOfGroups = c.GroupID;
                _colors.Add(c.GroupID, new Pen(Color.FromArgb(r,g,b)));
            }
            return true;
        }

    }
}
