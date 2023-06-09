﻿
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Fracion
{
    internal class Fraction
    {
        public Fraction() { }
        public Fraction(ushort integer) : this(integer,0,1) { }        
        public Fraction(ushort numerator, ushort denominator) : this(0, numerator, denominator) { }
        public Fraction(ushort integer, ushort numerator, ushort denominator)
        {
            Integer = integer;
            Numerator = numerator;
            Denominator = denominator;
        }

        private ushort integer = default;
        private ushort num = default;
        private ushort den = 1;
        public ushort Integer { get => integer; private set => integer = (value < 0 && value > ushort.MaxValue) ? (ushort)0 : value; }
        public ushort Numerator { get => num; private set => num = (value < 0 && value > ushort.MaxValue) ? (ushort)0 : value; }
        public ushort Denominator { get => den; private set => den = (value < 1 && value > ushort.MaxValue) ? (ushort)1 : value; }

        
        private delegate void DoubleValueSeparation (string value, out ushort integer, out ushort fraction, out byte size_fraction);
        private delegate void Swap<T> (ref T a, ref T b);
        private void CalculateTheInteger()
        {
            Integer = (ushort)(Numerator / Denominator);
            Numerator %= Denominator;
        }
        
        public void CutDown()
        {
            GetGCD((ushort)(Denominator * Integer + Numerator), Denominator, out ushort gcd);
            Numerator /= gcd; Denominator /= gcd;


            static void GetGCD(ushort num, ushort den, out ushort gcd) {
                while (num != den && num != 0)
                {
                    if (num > den) num -= den; else den -= num;
                }
                gcd = num > 0 ? num : (ushort)1;
            }
        }


        public override bool Equals(object? obj)
        {
            return this.ToString() == obj?.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator true (Fraction a)
        {
            Fraction zero = new(0);
            return a == zero ? false : true;
        }
        public static bool operator false (Fraction a)
        {
            Fraction zero = new(0);
            return a == zero ? false : true;
        }
        public static bool operator== (Fraction a, Fraction b)
        {
            return a.Equals(b);
        }
        public static bool operator!= (Fraction a, Fraction b)
        {
            return !(a == b);
        }
        public static bool operator> (Fraction a, Fraction b)
            => ((a.Numerator + a.Denominator * a.Integer) * b.Denominator) > ((b.Numerator + b.Denominator * b.Integer) * a.Denominator);
        public static bool operator< (Fraction a, Fraction b)
            => !(a > b);
        public static bool operator>= (Fraction a, Fraction b)
            => a > b || a == b;
        public static bool operator<= (Fraction a, Fraction b)
            => a < b || a == b;



       public static Fraction operator+ (Fraction a, Fraction b) {
            Fraction temp = new Fraction();
            temp.Numerator = (ushort)((a.Numerator + a.Denominator * a.Integer) * b.Denominator + (b.Numerator + b.Denominator * b.Integer) * a.Denominator);
            temp.Denominator = (ushort)(a.Denominator * b.Denominator);
            temp.CutDown();
            temp.CalculateTheInteger();
            return temp;
        }

        public delegate Fraction Sum_f_int(Fraction a, int b);
        Sum_f_int s_f_int = (Fraction a, int b) => new Fraction((ushort)(a.Integer + b), a.Numerator, a.Denominator);        
        
        public delegate Fraction Sum_int_f(int a, Fraction b);
        Sum_int_f s_int_f = (int a, Fraction b) => new Fraction((ushort)(b.Integer + a), b.Numerator, b.Denominator);       
        
        public delegate Fraction Sum_f_d(Fraction a, double b);
        Sum_f_d s_f_d = (Fraction a, double b) => a + b;

        public delegate Fraction Sum_d_f(double a, Fraction b);
        Sum_d_f s_d_f = (double a, Fraction b) => a + b;        
        

        public static Fraction operator- (Fraction a, Fraction b)
        {
            Swap<Fraction> Swap = delegate (ref Fraction a, ref Fraction b)
            {
            Fraction temp = a; a = b;
            b = temp;
            };
            Fraction temp = new Fraction();

            if (a < b) Swap (ref a, ref b);
            temp.Numerator = (ushort)((a.Denominator * a.Integer + a.Numerator) * b.Denominator - (b.Denominator * b.Integer + b.Numerator) * a.Denominator);
            temp.Denominator = temp.Numerator == 0 ? (ushort)1 : (ushort)(a.Denominator * b.Denominator);
            temp.CutDown();
            temp.CalculateTheInteger();

            return temp;            
        }

        public delegate Fraction Difference_f_int(Fraction a, int b);
        Difference_f_int dif_f_int = (Fraction a, int b) => a - new Fraction((ushort)b);
    
        public delegate Fraction Difference_int_f (int a, Fraction b);
        Difference_int_f dif_int_f = (int a, Fraction b) => new Fraction((ushort)a) - b;

        public delegate Fraction Difference_f_d(Fraction a, double b);
        Difference_f_d dif_f_d = (Fraction a, double b) => a - b;

        public delegate Fraction Difference_d_f(double a, Fraction b);
        Difference_d_f dif_d_f = (double a, Fraction b) => a - b;
       

        public static Fraction operator* (Fraction a, Fraction b)
        {            
            Fraction temp = new Fraction();
            temp.Numerator = (ushort)((a.Denominator * a.Integer + a.Numerator) * (b.Denominator * b.Integer + b.Numerator));
            temp.Denominator = (ushort)(a.Denominator * b.Denominator);
            temp.CutDown();
            temp.CalculateTheInteger();
            return temp;
        }

        public delegate Fraction Multiplication_f_int(Fraction a, int b);
        Multiplication_f_int m_f_int = (Fraction a, int b) => a * new Fraction((ushort)b);

        public delegate Fraction Multiplication_int_f(int a, Fraction b);
        Multiplication_int_f m_int_f = (int a, Fraction b) => new Fraction((ushort)a) * b;

        public delegate Fraction Multiplication_f_d(Fraction a, double b);
        Multiplication_f_d m_f_d = (Fraction a, double b) => a * b;

        public delegate Fraction Multiplication_d_f(double a, Fraction b);
        Multiplication_d_f m_d_f = (double a, Fraction b) => a * b;


        public static Fraction operator/ (Fraction a, Fraction b)
        {
            Fraction temp = new Fraction();
            temp.Numerator = (ushort)((a.Denominator * a.Integer + a.Numerator) * b.Denominator);
            temp.Denominator = (ushort)((b.Denominator * b.Integer + b.Numerator) * a.Denominator);
            temp.CutDown();
            temp.CalculateTheInteger();
            return temp;
        }

        public delegate Fraction Division_f_int(Fraction a, int b);
        Division_f_int div_f_int = (Fraction a, int b) => a / new Fraction((ushort)b);

        public delegate Fraction Division_int_f(int a, Fraction b);
        Division_int_f div_int_f = (int a, Fraction b) => new Fraction((ushort)a) / b;

        public delegate Fraction Division_f_d(Fraction a, double b);
        Division_f_d div_f_d = (Fraction a, double b) => a / b;

        public delegate Fraction Division_d_f(double a, Fraction b);
        Division_d_f div_d_f = (double a, Fraction b) => a / b;
        


        //public static implicit operator double(Fraction value)
        //    => (value.Denominator * value.Integer + value.Numerator) / (double)value.Denominator;

        public static implicit operator Fraction(double value)
        {
            DoubleValueSeparation? doubleValueSeparation = delegate (string value, out ushort integer, out ushort fraction, out byte size_fraction)
            {
                string[] parts = value.Split(',');
                integer = Convert.ToUInt16(parts[0]);

                if (parts.Length == 2)
                {
                    fraction = Convert.ToUInt16(parts[1]);
                    size_fraction = (byte)(parts[1].Length);
                }
                else
                {
                    fraction = 0;
                    size_fraction = 0;
                }
            };
            Fraction temp = new Fraction();

            doubleValueSeparation(Convert.ToString(value), out ushort integer, out ushort fraction, out byte size_fraction);
            temp.Integer = integer; temp.Numerator = fraction; temp.Denominator = (ushort)(Math.Pow(10, size_fraction));

            return temp;
        }

        public static implicit operator Fraction(int value)
            => new Fraction((ushort)value);

        public static explicit operator int(Fraction value)
            => value.Integer;


        public override string ToString() => $"{Integer} ({Numerator} / {Denominator})";        
    }
}
