using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 20)]
    internal class Task20_Obobshenie : Common.ITask
    {
        string ITask.Title => "Обобщения: Swap<T>, Max<T> с IComparable<T>";

        string ITask.Description => "Что сделать: написать обобщённые методы.";

        string[] ITask.Requirements => new[] { "Swap<T>(ref T a, ref T b) — меняет значения местами.", "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.", "Продемонстрировать на int, string, double.", "Swap — без ограничений, Max — с ограничением." };

        // ---------- Swap<T> — без ограничений ----------
        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        // ---------- Max<T> — с ограничением IComparable<T> ----------
        static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) >= 0 ? a : b;
        }

        void ITask.Run()
        {
            

           
            
                // ========== int ==========
                int x = 3, y = 7;
                Console.WriteLine($"[int] до Swap:    x={x}, y={y}");
                Swap(ref x, ref y);
                Console.WriteLine($"[int] после Swap: x={x}, y={y}");
                Console.WriteLine($"[int] Max(3, 7) = {Max(3, 7)}");
                Console.WriteLine($"[int] Max(7, 7) = {Max(7, 7)}");
                Console.WriteLine();

                // ========== string ==========
                string s1 = "apple", s2 = "banana";
                Console.WriteLine($"[string] до Swap:    s1=\"{s1}\", s2=\"{s2}\"");
                Swap(ref s1, ref s2);
                Console.WriteLine($"[string] после Swap: s1=\"{s1}\", s2=\"{s2}\"");
                Console.WriteLine($"[string] Max(\"apple\", \"banana\") = \"{Max("apple", "banana")}\"");
                Console.WriteLine();

                // ========== double ==========
                double d1 = 3.14, d2 = 2.71;
                Console.WriteLine($"[double] до Swap:    d1={d1}, d2={d2}");
                Swap(ref d1, ref d2);
                Console.WriteLine($"[double] после Swap: d1={d1}, d2={d2}");
                Console.WriteLine($"[double] Max(3.14, 2.71) = {Max(3.14, 2.71)}");
            
        }
    }
}
