using System;
using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 32)]
    internal class Task32_Temperature : Common.ITask
    {
        string ITask.Title => "Свойства с валидацией (Temperature)";

        string ITask.Description => "Что сделать: класс Temperature с валидацией в set.";

        string[] ITask.Requirements => new[] { "Свойство Celsius с проверкой в set: не ниже −273.15.", "При некорректном значении — бросать ArgumentOutOfRangeException.", "Вычисляемое свойство Fahrenheit (только get).", "Продемонстрировать корректное и некорректное присваивание." };



        void ITask.Run()
        {
            // значение через конструктор
            var t = new Temperature(25m);
            Console.WriteLine($"Значение в градусах С = {t.Celsius} °C, Значение в градусах F  = {t.Fahrenheit} °F");

            // Fahrenheit пересчитывается
            t.Celsius = 100m;
            Console.WriteLine($"Значение в градусах С  = {t.Celsius} °C, Значение в градусах F = {t.Fahrenheit} °F");

            // абсолютный ноль 
            t.Celsius = -273.15m;
            Console.WriteLine($"Значение в градусах С  = {t.Celsius} °C, Значение в градусах F = {t.Fahrenheit} °F");

            // исключение
            try
            {
                t.Celsius = -300m;
                Console.WriteLine("Это не должно напечататься");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"  Фактическое значение: {ex.ActualValue}");
            }

            
            Console.WriteLine($"После ошибки t.Celsius = {t.Celsius} °C (не изменилось)");

            
        }
    }
}
