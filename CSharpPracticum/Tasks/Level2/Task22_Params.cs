using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 22)]
    internal class Task22_Params : Common.ITask
    {
        string ITask.Title => "params-метод + перегрузка";

        string ITask.Description => "Что сделать: написать метод суммы с params и его перегрузку.";

        string[] ITask.Requirements => new[] { "Sum(params int[] numbers) — сумма произвольного числа чисел.", "Перегрузка Sum(int[] numbers) — та же логика для массива.", "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().", "Пустой вызов — вернуть 0." };

        //  params 
        static int Sum(params int[] numbers)
        {
            if (numbers == null) return 0;
            int total = 0;
            foreach (int n in numbers)
                total += n;
            return total;
        }

        public static int Sum(int a, int b) => a + b;

        void ITask.Run()
        {
            // params — произвольное число аргументов
            Console.WriteLine($"Sum(1, 2, 3)         = {Sum(1, 2, 3)}");

            // явный массив
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(new[] { 1, 2, 3 })}");

            // пустой вызов
            Console.WriteLine($"Sum()                = {Sum()}");

            // пустой массив и null
            Console.WriteLine($"Sum(new int[0])      = {Sum(new int[0])}");
            Console.WriteLine($"Sum(null)            = {Sum((int[])null)}");
        }
    }
}
