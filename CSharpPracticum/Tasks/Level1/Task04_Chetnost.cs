using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",4)]
    internal class Task04_Chetnost : Common.ITask
    {
        string ITask.Title => "Чётность числа (два способа)";

        string ITask.Description => "Что сделать: определить, чётное ли введённое число.";

        string[] ITask.Requirements => new[] { "Способ 1: через % 2 == 0.", "Способ 2: через тернарный оператор ? :.", "Оба способа реализовать отдельными методами.", "Вывести результат обоих способов." };

       
        void ITask.Run()
        {
            Console.WriteLine("Введите число для проверки чётности");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите вариант чётности");
            int b = Convert.ToInt32(Console.ReadLine());

            switch (b)
            { 
            case 1:
                    if (a%2==0) 
                    {
                        Console.WriteLine("Чётно");
                    }
                    else 
                    {
                        Console.WriteLine("Не чётно");
                    }
                    break;


            case 2:
                    Console.WriteLine($"{a} - {(a % 2 == 0 ? "чётное" : "нечётное")}");
                    break;

            default:
                    Console.WriteLine("Вариант не верный");
                    break;
            }


        }
    }
}

