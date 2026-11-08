using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 17)]
    internal class Task17_StringBuilder : Common.ITask
    {
        string ITask.Title => "StringBuilder vs конкатенация (замер)";

        string ITask.Description => "Что сделать: сравнить производительность конкатенации через + и StringBuilder.";

        string[] ITask.Requirements => new[] { "Собрать строку из 10 000 (или 100 000) чисел двумя способами.", "Замерить время каждого через Stopwatch.", "Вывести оба времени и разницу.", "Объяснить в комментарии, почему StringBuilder быстрее." };

        void ITask.Run()
        {
            const int count = 100_000;   

            // cпособ 1
            Stopwatch sw = Stopwatch.StartNew();
            string concat = ConcatWithPlus(count);
            sw.Stop();
            TimeSpan plusTime = sw.Elapsed;

            // cпособ 2
            sw.Restart();
            string sb = ConcatWithStringBuilder(count);
            sw.Stop();
            TimeSpan sbTime = sw.Elapsed;

            
            bool equal = concat == sb;

            
            Console.WriteLine($"Элементов:        {count:N0}");
            Console.WriteLine($"Конкатенация (+): {plusTime.TotalMilliseconds,10:F2} мс");
            Console.WriteLine($"StringBuilder:    {sbTime.TotalMilliseconds,10:F2} мс");
            Console.WriteLine($"Разница:          {(plusTime - sbTime).TotalMilliseconds,10:F2} мс");
            Console.WriteLine($"Ускорение:        {(sbTime.TotalMilliseconds > 0 ? plusTime.TotalMilliseconds / sbTime.TotalMilliseconds : 0):F1}x");
            Console.WriteLine($"Результаты равны: {equal}");
            Console.WriteLine($"Длина строки:     {sb.Length:N0}");
        }

        
        static string ConcatWithPlus(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
                result += i.ToString();
            return result;
        }

        
        static string ConcatWithStringBuilder(int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
                sb.Append(i);
            return sb.ToString();
        }
    }
}
