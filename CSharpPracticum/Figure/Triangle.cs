using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Figure
{
    public class Triangle : IShape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public string Name => "Треугольник";

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны > 0");
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Нарушено неравенство треугольника");
            A = a; B = b; C = c;
        }

        public double Area()
        {
            double p = Perimeter() / 2;              // полупериметр
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));   // Герон
        }

        public double Perimeter() => A + B + C;

        public override string ToString() =>
            $"{Name} ({A},{B},{C}): S={Area():F2}, P={Perimeter():F2}";
    }
}

