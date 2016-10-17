using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Model
{
    class Cell
    {
        private bool _isNew = true;
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            set
            {
                _isNew = false;
            }
        }

        private bool _isCounted = false;
        public bool IsCounted
        {
            get
            {
                return _isCounted;
            }
            set
            {
                _isCounted = true;
            }
        }
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
