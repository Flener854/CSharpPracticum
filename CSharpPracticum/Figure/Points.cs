using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Figure
{
    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

       
        public bool Equals(Point? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return X == other.X && Y == other.Y;
        }

       
        public override bool Equals(object? obj)
        {
            // obj == null → false; obj другого типа → false
            return Equals(obj as Point);
        }

       
        public override int GetHashCode()
        {
            // Хэш должен зависеть от ТЕХ ЖЕ полей, что и Equals
            return HashCode.Combine(X, Y);   
        }

        
        public static bool operator ==(Point? a, Point? b)
            => Equals(a, b);                

        public static bool operator !=(Point? a, Point? b)
            => !Equals(a, b);

        public override string ToString() => $"({X}, {Y})";
    }
}
