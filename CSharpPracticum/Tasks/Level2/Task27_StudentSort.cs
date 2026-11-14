using CSharpPracticum.Common;
using CSharpPracticum.Stud;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 27)]
    internal class Task27_StudentSort : Common.ITask
    {
        string ITask.Title => "IComparable / IComparer<T> для Student";

        string ITask.Description => "Что сделать: научить Student сортироваться.";

        string[] ITask.Requirements => new[] { "Класс Student: Name, AverageGrade.", "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).", "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.", "Продемонстрировать обе сортировки на List<Student>." };

        static void Print(List<Student> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1}. {list[i]}");
        }

        void ITask.Run()
        {
            var students = new List<Student>
        {
            new Student("Иван",  4.5),
            new Student("Анна",  3.8),
            new Student("Пётр",  4.9),
            new Student("Мария", 5.0),
            new Student("Олег",  3.2)
        };

            Console.WriteLine("=== Исходный список ===");
            Print(students);

            // 1) IComparable — естественный порядок (по баллу, убывание)
            students.Sort();                       // использует CompareTo
            Console.WriteLine("\n=== По среднему баллу (убывание) — IComparable ===");
            Print(students);

            // 2) IComparer — по имени (возрастание)
            students.Sort(new ByNameComparer());   // использует внешний компаратор
            Console.WriteLine("\n=== По имени (возрастание) — IComparer ===");
            Print(students);
        }
    }
}
