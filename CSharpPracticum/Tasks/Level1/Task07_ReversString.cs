using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",7)]
    internal class Task07_ReversString : Common.ITask
    {
        string ITask.Title => "Реверс строки без LINQ";

        string ITask.Description => "Что сделать: перевернуть введённую строку.";

        string[] ITask.Requirements => new[] { "Не использовать Array.Reverse и LINQ.", "Реализовать через цикл for от конца к началу (или через char[] и swap).", "Пустая строка и строка из одного символа — обрабатываются корректно."};


        void ITask.Run()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? "";

            char[] result = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = input[input.Length - 1 - i];   
            }

            string reversed = new string(result);
            Console.WriteLine($"Реверс: {reversed}");
        }
    }
}