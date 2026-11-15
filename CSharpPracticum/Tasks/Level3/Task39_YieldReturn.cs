using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 4)]
    internal class Task39_YieldReturn : Common.ITask
    {
        string ITask.Title => "yield return — генератор чётных чисел";

        string ITask.Description => "Что сделать: реализовать генератор чётных чисел через yield return.";

        string[] ITask.Requirements => new[] { "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max.", "Реализовать именно через yield return, без промежуточного списка.", "Продемонстрировать работу в foreach.", "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному." };

        public static IEnumerable<int> GetEvenNumbers(int max)
        {
            Console.WriteLine("--- Генератор: НАЧАЛО работы ---");

            for (int i = 0; i <= max; i += 2)
            {
               
                Console.WriteLine($"--- Генератор: подготовлено число {i}, отдаём управление (yield) ---");
                yield return i;
                Console.WriteLine($"--- Генератор: управление вернулось после числа {i} ---");
            }

            Console.WriteLine("--- Генератор: КОНЕЦ работы ---");
        }

        void ITask.Run()
        {
            Console.WriteLine("=== Демонстрация генератора чётных чисел ===");
            Console.WriteLine("Запускаем foreach. Обратите внимание на порядок вывода.\n");

            
            foreach (int number in GetEvenNumbers(10))
            {
                Console.WriteLine($"[Из foreach] Получено число: {number}");
            }

            Console.WriteLine("\n=== Демонстрация явной отложенности ===");

            var generator = GetEvenNumbers(6);
            Console.WriteLine("1. Генератор создан, но метод ещё НЕ выполнялся (нет сообщений от генератора).");

            Console.WriteLine("2. Запрашиваем первый элемент вручную...");
            using var enumerator = generator.GetEnumerator();
            enumerator.MoveNext(); // Вот теперь генератор проснётся и дойдёт до первого yield
            Console.WriteLine($"[Из foreach] Получено число: {enumerator.Current}");
        }
    }
}
