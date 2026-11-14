using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 23)]
    internal class Task23_Nullable : Common.ITask
    {
        string ITask.Title => " Nullable-типы, ??, ?.";

        string ITask.Description => "Что сделать: продемонстрировать работу с nullable.";

        string[] ITask.Requirements => new[] { "Метод int? FindValue(string key) — возвращает null, если ключа нет.", "Использовать ?? для значения по умолчанию.", "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.", "Использовать HasValue / Value с проверкой.", "Продемонстрировать на примере с найденным и ненайденным ключом." };

        static readonly Dictionary<string, int> Data = new()
        {
            ["apple"] = 10,
            ["banana"] = 20,
            ["cherry"] = 30
        };

        //  1. Метод, возвращающий int? 
        static int? FindValue(string key)
        {
            if (key == null) return null;
            return Data.TryGetValue(key, out int value) ? value : null;
        }

        // Класс для демонстрации ?. 
        class Person
        {
            public string? Name { get; set; }
            public Address? Home { get; set; }
        }

        class Address
        {
            public string? City { get; set; }
        }


        void ITask.Run()
        {
            //  Сценарий 1: ключ найден 
            Console.WriteLine("=== Ключ найден: \"banana\" ===");
            int? found = FindValue("banana");

            // HasValue / Value с проверкой
            if (found.HasValue)
                Console.WriteLine($"HasValue=true, Value={found.Value}");
            else
                Console.WriteLine("HasValue=false");

            // ?? — значение по умолчанию
            int withDefault = found ?? -1;
            Console.WriteLine($"found ?? -1 = {withDefault}");

            // Сценарий 2: ключ не найден 
            Console.WriteLine("\n=== Ключ не найден: \"mango\" ===");
            int? missing = FindValue("mango");

            if (missing.HasValue)
                Console.WriteLine($"HasValue=true, Value={missing.Value}");
            else
                Console.WriteLine($"HasValue=false → missing ?? -1 = {missing ?? -1}");

            

            // Сценарий 3: ?. — безопасный доступ
            Console.WriteLine("\n=== ?. — безопасный доступ ===");

            Person? withAddress = new Person
            {
                Name = "Иван",
                Home = new Address { City = "Москва" }
            };

            Person? withoutAddress = new Person { Name = "Пётр", Home = null };
            Person? nobody = null;

            // ?. + ??
            string city1 = withAddress?.Home?.City ?? "город не указан";
            string city2 = withoutAddress?.Home?.City ?? "город не указан";
            string city3 = nobody?.Home?.City ?? "город не указан";

            Console.WriteLine($"withAddress:    {city1}");
            Console.WriteLine($"withoutAddress: {city2}");
            Console.WriteLine($"nobody:         {city3}");

            // Длина имени через ?. — тоже безопасно
            int nameLength = nobody?.Name?.Length ?? 0;
            Console.WriteLine($"nobody?.Name?.Length ?? 0 = {nameLength}");
        }

    }
}
