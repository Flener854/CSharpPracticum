using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task11_Diagonal : Common.ITask
    {
        string ITask.Title => "Диагональ матрицы N×N";

        string ITask.Description => "Что сделать: найти сумму элементов главной диагонали матрицы N×N.";

        string[] ITask.Requirements => new[] { "Размер N вводится пользователем (минимум 2).", "Матрица заполняется случайными числами.", "Сумма считается без LINQ, в одном цикле for.", "Вывести саму матрицу и сумму." };


        void ITask.Run()
        {
            int n;
            while (true)
            {
                Console.Write("Введите размер матрицы N (>= 2): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 2)
                    break;
                Console.WriteLine("Ошибка: нужно целое число >= 2. Попробуйте снова.");
            }

            
            int[,] matrix = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = rnd.Next(1, 10);   

            
            Console.WriteLine("\nМатрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }

            
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += matrix[i, i];

            Console.WriteLine($"\nСумма главной диагонали: {sum}");
        }
    }
}
