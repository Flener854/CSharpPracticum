using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",13)]
    internal class Task13_Dictionary : Common.ITask
    {
        string ITask.Title => "Счётчик вхождений слов в тексте (Dictionary)";

        string ITask.Description => "Что сделать: посчитать, сколько раз каждое слово встречается в тексте.";

        string[] ITask.Requirements => new[] { "Использовать Dictionary<string, int>.", "Разбить текст на слова (по пробелам и знакам пунктуации).", "Привести слова к нижнему регистру.", "Вывести пары «слово → количество», отсортированные по убыванию количества." };

        static Dictionary<string, int> CountWords(string text)
        {
            var counts = new Dictionary<string, int>();

            // разбиваем по всему, что не буква/цифра
            string[] words = text.Split(
                new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '-', '—',
                    '"', '\'', '(', ')', '[', ']', '{', '}' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string raw in words)
            {
                string word = raw.ToLowerInvariant();  
                if (word.Length == 0) continue;

                if (counts.TryGetValue(word, out int current))
                    counts[word] = current + 1;         
                else
                    counts[word] = 1;                   
            }

            return counts;
        }

        void ITask.Run()
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine() ?? "";

            var counts = CountWords(text);

            //  сортировка по убыванию количества 
            var sorted = new List<KeyValuePair<string, int>>(counts);
            sorted.Sort((a, b) =>
            {
                int byCount = b.Value.CompareTo(a.Value);   
                return byCount != 0 ? byCount
                                    : string.Compare(a.Key, b.Key, StringComparison.Ordinal);
            });

            // вывод
            foreach (var pair in sorted)
                Console.WriteLine($"{pair.Key} → {pair.Value}");
        }
    }
}
