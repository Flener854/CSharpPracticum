using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 2)]
    internal class Task37_Dictionary : Common.ITask
    {
        string ITask.Title => "Мемоизация Фибоначчи через Dictionary";

        string ITask.Description => "Что сделать: реализовать мемоизированную функцию Фибоначчи.";

        string[] ITask.Requirements => new[] { "Обычная рекурсивная версия (для сравнения на маленьком N).", "Мемоизированная версия с Dictionary<int, long>.", "Замерить время обеих на N = 30–35 через Stopwatch.", "Вывести оба времени и разницу." };

        private static readonly Dictionary<int, long> _cache = new() { [0] = 0, [1] = 1 };


        public static long FibonacciPlain(int n)
        {
            if (n <= 1) return n;
            return FibonacciPlain(n - 1) + FibonacciPlain(n - 2);
        }

        
        public static long FibonacciMemo(int n)
        {
            if (_cache.TryGetValue(n, out long cached))
                return cached;

            long result = FibonacciMemo(n - 1) + FibonacciMemo(n - 2);
            _cache[n] = result;
            return result;
        }
        void ITask.Run()
        {
            int n = 35;

            // Обычная рекурсия
            var sw = Stopwatch.StartNew();
            long plainResult = FibonacciPlain(n);
            sw.Stop();
            var plainTime = sw.ElapsedMilliseconds;

            // Мемоизированная версия
            sw.Restart();
            long memoResult = FibonacciMemo(n);
            sw.Stop();
            var memoTime = sw.ElapsedMilliseconds;

            
            Console.WriteLine($"N = {n}");
            Console.WriteLine($"Обычная рекурсия:    {plainResult,15} | {plainTime,6} мс");
            Console.WriteLine($"С мемоизацией:       {memoResult,15} | {memoTime,6} мс");
            Console.WriteLine($"Результаты совпадают: {plainResult == memoResult}");

            if (memoTime > 0)
            {
                Console.WriteLine($"Разница: мемоизация быстрее в ~{plainTime / memoTime} раз");
            }
            else
            {
                Console.WriteLine($"Разница: мемоизация быстрее (заняла < 1 мс)");
            }
        }
    }
}
