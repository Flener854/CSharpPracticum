using System;
using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System.Collections.Generic;
using System.Text;


namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2",16)]

    internal class Task16_String_ : Common.ITask
    {
        string ITask.Title => "Методы расширения для string";

        string ITask.Description => "Что сделать: написать extension-методы для string.";

        string[] ITask.Requirements => new[] { "Реализовать в статическом классе StringExtensions.", "Методы: IsPalindrome(), WordCount(), ReverseString().", "Методы должны быть public static с this string первым параметром.", "Продемонстрировать вызов на 2–3 строках." };



        void ITask.Run()
        {
            string[] samples =
            {
                "А роза упала на лапу Азора",
                "hello world, this is C#!",
                "abc"
            };

            foreach (string line in samples)
            {
                Console.WriteLine($"Строка: \"{line}\"");
                Console.WriteLine($"  ReverseString() → \"{line.ReverseString()}\"");
                Console.WriteLine($"  WordCount()     → {line.WordCount()}");
                Console.WriteLine($"  IsPalindrome()  → {line.IsPalindrome()}");
                Console.WriteLine();
            }
        }
    }
}
