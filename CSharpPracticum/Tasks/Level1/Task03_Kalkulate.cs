using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task03_Kalkulate : Common.ITask
    {
        string ITask.Title => "Калькулятор с обработкой деления на ноль";

        string ITask.Description => "Что сделать: принимать два числа и оператор (+ - * /), выводить результат. ";

        string[] ITask.Requirements => new[] { "Оператор обрабатывать через switch.", "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.", "Некорректный оператор — вывести «Неизвестная операция».", "Ввод чисел — через double.Parse или TryParse." };

        void ITask.Run()
        {
            Console.WriteLine("Введите 2 значения ");
             double a = Double.Parse(Console.ReadLine());
            double b = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите оператор: + - * / ");
            char c = Convert.ToChar(Console.ReadLine());

            switch(c)
            {
                case '+':
                    Console.WriteLine(a + b);
                    break;
                case '-':
                    Console.WriteLine(a - b);
                    break;
                case '*':
                    Console.WriteLine(a * b);
                    break;
                case '/':
                    if (b==0) 
                    { 
                        Console.WriteLine("Делить на ноль не стоит");
                    }
                    Console.WriteLine(a / b);
                    
                    break;
                default: Console.WriteLine("Неизвестная операция");
                    break;


            }

        }
    }
}
