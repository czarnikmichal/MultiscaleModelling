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

        public override bool Equals(Object o)
        {
            Coordinate c2 = (Coordinate)o;
            if (this.CoordinateX != c2.CoordinateX)
                return false;
            if (this.CoordinateY != c2.CoordinateY)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((this.CoordinateX == -1) ? 0 : this.CoordinateX);
            result = prime * result + ((this.CoordinateY == -1) ? 0 : this.CoordinateY);
            return result;
        }
    }

}
