using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using CSharpPracticum.Figure;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 27)]
    internal class Task28_Point : Common.ITask
    {
        string ITask.Title => "Equals / GetHashCode для Point";

        string ITask.Description => "Что сделать: переопределить Equals и GetHashCode для класса Point(x, y).";

        string[] ITask.Requirements => new[] { "Переопределить Equals(object) и GetHashCode().", "Реализовать IEquatable<Point>.", "Проверить: две точки с одинаковыми координатами равны.", "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count." };



        void ITask.Run()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            var p3 = new Point(3, 4);

            //Equals — одинаковые координаты → true
            Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}");            // True
            Console.WriteLine($"p1.Equals(p3) = {p1.Equals(p3)}");            // False
            Console.WriteLine($"p1 == p2      = {p1 == p2}");                // True (через оператор)
            Console.WriteLine($"p1 == p3      = {p1 == p3}");                // False

            //GetHashCode — у равных объектов ОДИНАКОВЫЙ
            Console.WriteLine($"\np1.GetHashCode() = {p1.GetHashCode()}");
            Console.WriteLine($"p2.GetHashCode() = {p2.GetHashCode()}");
            Console.WriteLine($"Хэши равны: {p1.GetHashCode() == p2.GetHashCode()}");   // True

            //HashSet — дубликат не увеличивает Count
            var set = new HashSet<Point>();
            Console.WriteLine($"\nДобавляем p1: {set.Add(p1)}, Count={set.Count}");    // True, 1
            Console.WriteLine($"Добавляем p2: {set.Add(p2)}, Count={set.Count}");      // False, 1
            Console.WriteLine($"Добавляем p3: {set.Add(p3)}, Count={set.Count}");      // True, 2

            Console.WriteLine($"\nHashSet: [{string.Join(", ", set)}]");
        }
    }
}
