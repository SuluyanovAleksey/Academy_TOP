using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal struct Point
    {
        public int X { get; private set; } = default;
        public int Y { get; private set; } = default;


        public Point() { }
        public Point(int x, int y) { X = x; Y = y; }

    }
}
