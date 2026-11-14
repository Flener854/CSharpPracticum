using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",14)]
    internal class Task14_VozrastPoDate : Common.ITask
    {
        string ITask.Title => "Возраст по дате рождения";

        string ITask.Description => "Что сделать: по дате рождения вычислить точный возраст в годах, месяцах и днях.";

        string[] ITask.Requirements => new[] { "Ввод даты через DateTime.TryParse (или TryParseExact).", "Учесть, что день рождения в этом году мог ещё не наступить.", "Вывести «X лет, Y месяцев, Z дней».", "Некорректная дата — сообщение об ошибке, не падать." };

        static (int years, int months, int days) GetAge(DateTime birth, DateTime today)
        {
            int years = today.Year - birth.Year;
            int months = today.Month - birth.Month;
            int days = today.Day - birth.Day;

            // если день ещё не наступил в текущем месяце — «занимаем» месяц
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(
                    months < 0 ? today.Year - 1 : today.Year,
                    months < 0 ? 12 : (today.Month == 1 ? 12 : today.Month - 1));
            }

            // если месяц ещё не наступил в текущем году — «занимаем» год
            if (months < 0)
            {
                years--;
                months += 12;
            }

            return (years, months, days);
        }

        void ITask.Run()
        {
            Console.Write("Введите дату рождения (например, 1990-05-15): ");
            string input = Console.ReadLine() ?? "";

           
            if (!DateTime.TryParseExact(input, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime birth))
            {
                Console.WriteLine("Ошибка: не удалось распознать дату. Ожидается формат ГГГГ-ММ-ДД.");
                return;
            }

            DateTime today = DateTime.Today;

            if (birth > today)
            {
                Console.WriteLine("Ошибка: дата рождения в будущем.");
                return;
            }

            (int years, int months, int days) = GetAge(birth, today);
            Console.WriteLine($"{years} лет, {months} месяцев, {days} дней");
        }
    }
}
