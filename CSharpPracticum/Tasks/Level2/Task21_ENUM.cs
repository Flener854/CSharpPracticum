using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 21)]
    internal class Task21_ENUM : Common.ITask
    {
        string ITask.Title => "enum дни недели";

        string ITask.Description => "Что сделать: описать дни недели через enum и определить тип дня.";

        string[] ITask.Requirements => new[] { "enum DayOfWeek { Monday, ..., Sunday }.", "Методы: IsPalindrome(), WordCount(), ReverseString().", "Методы должны быть public static с this string первым параметром.", "Продемонстрировать вызов на 2–3 строках." };

        
        static bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        
        static string GetRussianName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестный день";
            }
        }
        public enum DayOfWeek
        {
            Monday,     // 0
            Tuesday,    // 1
            Wednesday,  // 2
            Thursday,   // 3
            Friday,     // 4
            Saturday,   // 5
            Sunday      // 6
        }

        void ITask.Run()
        {
            Console.WriteLine($"{"День",-12} {"Название",-12} {"Выходной?"}");
            Console.WriteLine(new string('-', 36));

            // Демонстрация на всех 7 днях
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                string name = GetRussianName(day);
                bool weekend = IsWeekend(day);
                Console.WriteLine($"{day,-12} {name,-12} {(weekend ? "да" : "нет")}");
            }
        }
    }
}
