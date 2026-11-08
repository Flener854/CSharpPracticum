using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Stud
{
    public class Student : IComparable<Student>
    {
        public string Name { get; }
        public double AverageGrade { get; }

        public Student(string name, double averageGrade)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            if (averageGrade < 0 || averageGrade > 5)
                throw new ArgumentOutOfRangeException(nameof(averageGrade), "Балл 0..5");

            Name = name;
            AverageGrade = averageGrade;
        }

        // Естественный порядок: по убыванию среднего балла
        public int CompareTo(Student? other)
        {
            if (other is null) return 1;          // null «больше» любого объекта
            if (ReferenceEquals(this, other)) return 0;

            // По убыванию: b.CompareTo(a), т.е. больший балл — раньше
            return other.AverageGrade.CompareTo(AverageGrade);
        }

        public override string ToString() =>
            $"{Name,-12} {AverageGrade:F2}";
    }


    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

}
