using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",9)]
    internal class Task09_Array : Common.ITask
    {
        string ITask.Title => "Массивы: min/max/sum/avg";

        string ITask.Description => "Что сделать: для массива чисел найти минимум, максимум, сумму и среднее.";

        string[] ITask.Requirements => new[] { "Заполнить массив (например, случайными числами 1–100, размер 20).", "Реализовать без LINQ (Min/Max/Sum/Average запрещены)", "Оформить 4 отдельных метода.", "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."};

        static int Min(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min) min = arr[i];
            return min;
        }

        static int Max(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max;
        }

        static int Sum(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            return sum;
        }

        static double Average(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;

            return (double)Sum(arr) / arr.Length;   
        }

        void ITask.Run()
        {
            const int size = 20;
            int[] numbers = new int[size];

            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                numbers[i] = rnd.Next(1, 101);   

            Console.WriteLine("Массив: " + string.Join(", ", numbers));

            Console.WriteLine($"Min: {Min(numbers)}");
            Console.WriteLine($"Max: {Max(numbers)}");
            Console.WriteLine($"Sum: {Sum(numbers)}");
            Console.WriteLine($"Avg: {Average(numbers):F2}");
        }
    }
}
