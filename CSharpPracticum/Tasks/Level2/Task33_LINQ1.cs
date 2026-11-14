using System;
using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 33)]
    internal class Task33_LINQ1 : Common.ITask
    {
        string ITask.Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";

        string ITask.Description => "Что сделать: LINQ-запросы по списку сотрудников.";

        string[] ITask.Requirements => new[] { "Класс Employee: Name, Age, Salary, Department.", "Список из 10+ сотрудников.", "Запросы через LINQ: топ-3 по зарплате (убывание);\nсредняя зарплата по каждому отделу (GroupBy + Average);\nсотрудники старше 30 (Where).", "Вывести результаты." };



        void ITask.Run()
        {
            var employees = new List<Employee>
        {
            new("Анна",     28, 120_000m, "IT"),
            new("Борис",    35,  95_000m, "IT"),
            new("Вера",     42, 150_000m, "IT"),
            new("Глеб",     31,  80_000m, "Finance"),
            new("Дарья",    26,  75_000m, "Finance"),
            new("Егор",     45, 110_000m, "Finance"),
            new("Жанна",    38, 100_000m, "HR"),
            new("Зиновий",  29,  60_000m, "HR"),
            new("Ирина",    52,  85_000m, "HR"),
            new("Кирилл",   33, 130_000m, "IT"),
            new("Лариса",   40,  70_000m, "Marketing"),
            new("Максим",   24,  55_000m, "Marketing"),
        };

            // 1) Топ-3 по зарплате (убывание)
            Console.WriteLine("=== Топ-3 по зарплате ===");
            var top3 = employees
                .OrderByDescending(e => e.Salary)
                .Take(3);

            int rank = 1;
            foreach (var e in top3)
                Console.WriteLine($"{rank++}. {e}");

            // 2) Средняя зарплата по отделам
            Console.WriteLine("\n=== Средняя зарплата по отделам ===");
            var avgByDept = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Average = g.Average(e => e.Salary),
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Average);

            foreach (var d in avgByDept)
                Console.WriteLine($"{d.Department,-10} | средняя {d.Average,10:F2} | сотрудников: {d.Count}");

            // 3) Сотрудники старше 30
            Console.WriteLine("\n=== Сотрудники старше 30 ===");
            var olderThan30 = employees
                .Where(e => e.Age > 30)
                .OrderBy(e => e.Age);

            foreach (var e in olderThan30)
                Console.WriteLine(e);
            Console.WriteLine($"Итого: {olderThan30.Count()} из {employees.Count}");
        }
    }
}
