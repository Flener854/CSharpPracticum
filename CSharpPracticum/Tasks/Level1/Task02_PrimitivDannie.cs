using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",2)]
    internal class Task02_PrimitivDannie : Common.ITask
    {
        string ITask.Title => "Переменные примитивных типов";

        string ITask.Description => "Что сделать: объявить переменные всех примитивных типов и вывести их значения и типы. ";

        string[] ITask.Requirements => new[] { "Объявить минимум: int, long, double, float, decimal, bool, char, string", "Для каждой переменной вывести значение и GetType().Name.", "decimal — с суффиксом m, float — с f." };

        void ITask.Run()
        {
            int a = 1;
            long b = 2;
            double c = 3;
            float d = 4;
            decimal e = 5;
            bool f = true;
            char g = 'A';
            string s = "aa";
             
            Console.WriteLine($"a = {a} ({a.GetType().Name}) ");
            Console.WriteLine($"b = {b} ({b.GetType().Name}) ");
            Console.WriteLine($"c = {c} ({c.GetType().Name}) ");
            Console.WriteLine($"d = {d} ({d.GetType().Name}) f ");
            Console.WriteLine($"e = {e} ({e.GetType().Name}) m ");
            Console.WriteLine($"f = {f} ({f.GetType().Name}) ");
            Console.WriteLine($"g = {g} ({g.GetType().Name}) ");
            Console.WriteLine($"ss = {s} ({s.GetType().Name}) ");
        }
    }
}
