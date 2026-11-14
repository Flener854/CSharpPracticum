using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 6)]
    internal class Task41_TaskWhenAll : Common.ITask
    {
        string ITask.Title => "Task.WhenAll — параллельно 10 задач";

        string ITask.Description => "Что сделать: запустить 10 задач параллельно и сравнить с последовательным выполнением.";

        string[] ITask.Requirements => new[] { "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id.", "Последовательный запуск 10 задач в цикле с await.", "Параллельный запуск через Task.WhenAll.", "Замерить время обоих вариантов через Stopwatch.", "Вывести оба времени и объяснить разницу." };

        public static async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }

        public static async Task Maine()
        {
            const int taskCount = 10;

            Console.WriteLine($"=== Запуск {taskCount} задач ===");
            Console.WriteLine("Каждая задача занимает ~500 мс.\n");

            // Последовательное выполнение 
            var sw = Stopwatch.StartNew();
            var sequentialResults = new int[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                // await блокирует текущий метод до завершения задачи,
                // поэтому следующая задача стартует только после предыдущей.
                sequentialResults[i] = await WorkAsync(i);
            }

            sw.Stop();
            var sequentialTime = sw.ElapsedMilliseconds;

            // Параллельное выполнение 
            sw.Restart();

            // Создаём массив задач. Каждая стартует СРАЗУ при вызове WorkAsync.
            var tasks = Enumerable.Range(0, taskCount)
                                  .Select(i => WorkAsync(i))
                                  .ToArray();

            // Task.WhenAll ждёт завершения ВСЕХ задач одновременно
            var parallelResults = await Task.WhenAll(tasks);

            sw.Stop();
            var parallelTime = sw.ElapsedMilliseconds;

            
            Console.WriteLine($"\n{new string('-', 50)}");
            Console.WriteLine($"Последовательное выполнение: {sequentialTime,4} мс");
            Console.WriteLine($"Параллельное выполнение:     {parallelTime,4} мс");

            if (parallelTime > 0)
                Console.WriteLine($"Ускорение: в ~{sequentialTime / (double)parallelTime:F1} раз");

            Console.WriteLine($"{new string('-', 50)}");
            Console.WriteLine($"Результаты последовательные: [{string.Join(", ", sequentialResults)}]");
            Console.WriteLine($"Результаты параллельные:     [{string.Join(", ", parallelResults)}]");

            bool same = sequentialResults.SequenceEqual(parallelResults);
            Console.WriteLine($"Результаты совпадают: {same}");
        }


        void ITask.Run()
        {
            Maine();
        }
    }
}
