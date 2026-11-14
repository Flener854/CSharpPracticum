using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 34)]
    internal class Task34_LINQ2 : Common.ITask
    {
        string ITask.Title => "LINQ: группировка слов по первой букве";

        string ITask.Description => "Что сделать: сгруппировать слова по первой букве.";

        string[] ITask.Requirements => new[] { "Взять список слов (10+).", "Сгруппировать через LINQ GroupBy(w => w[0]).", "Отсортировать группы по первой букве.", "Внутри группы — отсортировать слова.", "Вывести «Буква: слово1, слово2, ...»." };


        void ITask.Run()
        {
            var words = new List<string>
            {
            "яблоко", "банан", "арбуз", "вишня", "абрикос",
            "брусника", "ягода", "апельсин", "виноград", "берёза",
            "автомобиль", "якорь", "бабочка", "волк", "альбом"
            };

            var grouped = words
                .GroupBy(w => w[0])                       // группа по первой букве
                .OrderBy(g => g.Key)                      // группы по алфавиту
                .Select(g => new
                {
                    Letter = g.Key,
                    Words = g.OrderBy(w => w, StringComparer.CurrentCulture) // слова внутри
                });


            foreach (var i in words)
            {
                Console.Write($"{i}\u0020");
            }
            Console.WriteLine(" ");

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Letter}: {string.Join(", ", group.Words)}");   
            }
        }
    }
}
