using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 1)]
    internal class Task36_HashSetGroupBy : Common.ITask
    {
        string ITask.Title => "Дубликаты в List (HashSet + GroupBy)";

        string ITask.Description => "Что сделать: найти дубликаты в списке чисел двумя способами.";

        string[] ITask.Requirements => new[] { "Способ 1: через HashSet<int> — при добавлении проверять Contains.", "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1).", "Оба способа оформить отдельными методами.", "Продемонстрировать на списке с повторяющимися значениями." };

        public static List<int> FindDuplicatesWithHashSet(IEnumerable<int> numbers)
        {
            var seen = new HashSet<int>();
            var duplicates = new HashSet<int>();

            foreach (var n in numbers)
            {
                if (!seen.Add(n))      // add возвращает false, если элемент уже был
                    duplicates.Add(n); // добавляем в дубликаты (HashSet отсечёт повторы)
            }

            return duplicates.ToList();
        }

       
        public static List<int> FindDuplicatesWithLinq(IEnumerable<int> numbers)
        {
            return numbers
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
        }

        void ITask.Run()
        {
            var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6, 7, 7, 1, 8 };

            Console.WriteLine("Исходный список: " + string.Join(", ", numbers));

            var hashSetDuplicates = FindDuplicatesWithHashSet(numbers);
            var linqDuplicates = FindDuplicatesWithLinq(numbers);

            Console.WriteLine("\nСпособ 1 (HashSet): " + string.Join(", ", hashSetDuplicates));
            Console.WriteLine("Способ 2 (GroupBy): " + string.Join(", ", linqDuplicates));

            // сравнение
            var set1 = new HashSet<int>(hashSetDuplicates);
            var set2 = new HashSet<int>(linqDuplicates);

            bool same = set1.SetEquals(set2);
            Console.WriteLine($"\nРезультаты совпадают: {same}");
        }
        
        
        
        
    }
}
