using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Node
    {
        private bool _isOptr;
        private bool _isPoint;
        private double _data;
        private Node _left;
        private Node _right;
        public bool IsPoint
        {
            get { return _isPoint; }
        }

        public bool IsOptr
        {
            get{ return _isOptr; }
        }

        public double Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Node Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public Node(double data)
        {
            _isOptr = false;
            _data = data;
        }

        public Node(char data)
        {
            _isOptr = true;
            _data = data;
        }

        public override string ToString()
        {
            if (_isOptr)
            {
                return Convert.ToString((char)_data);
            }
            else
            {
                return _data.ToString();
            }
        }
    }
}
