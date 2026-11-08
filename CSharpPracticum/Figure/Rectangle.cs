using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Figure
{
    public class Rectanglel : IShape
    {
        public double Width { get; }
        public double Height { get; }
        public string Name => "Прямоугольник";

        public Rectanglel(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Стороны > 0");
            Width = width;
            Height = height;
        }

        public double Area() => Width * Height;
        public double Perimeter() => 2 * (Width + Height);

        public override string ToString() =>
            $"{Name} ({Width}×{Height}): S={Area():F2}, P={Perimeter():F2}";
    }
}
