using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    internal class Vector
    {
        public int X { get; private set; } = default;
        public int Y { get; private set; } = default; 

        public Vector(Point A, Point B)
        {
            X = B.X - A.X;
            Y = B.Y - A.Y;
        }

        public double Length() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        
        

        //public double length()
        //{
        //    return Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y,2))
        //}
    }
}
