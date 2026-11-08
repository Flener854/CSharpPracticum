using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Figure
{
    public class Circle : IShape
    {
        public double Radius { get; }
        public string Name => "Круг";

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException("Радиус > 0", nameof(radius));
            Radius = radius;
        }

        public double Area() => Math.PI * Radius * Radius;
        public double Perimeter() => 2 * Math.PI * Radius;

        public override string ToString() =>
            $"{Name} (R={Radius}): S={Area():F2}, P={Perimeter():F2}";
    }
}
