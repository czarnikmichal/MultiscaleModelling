using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Cell
    {
        public Cell(int value)
        {
            _groupId = value;
        }
        private int _groupId=-1;
        public int GroupID
        {
            get
            {
                return _groupId;
            }
            set
            {
                _groupId = value;
            }
        }
    }
}
