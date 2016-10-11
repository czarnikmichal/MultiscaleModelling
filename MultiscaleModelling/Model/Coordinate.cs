using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Coordinate
    {
        public Coordinate(int x, int y)
        {
            _coordinateX = x;
            _coordinateY = y;
        }
        private int _coordinateX = -1;
        private int _coordinateY = -1;
        public int CoordinateX
        {
            get
            {
                return _coordinateX;
            }
            set
            {
                _coordinateX = value;
            }
        }
        public int CoordinateY
        {
            get
            {
                return _coordinateY;
            }
            set
            {
                _coordinateY = value;
            }
        }
    }
}
