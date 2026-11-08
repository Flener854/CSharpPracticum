using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;


namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]

    internal class Task06_SummChisl : Common.ITask
    {
        string ITask.Title => "Сумма цифр числа (строка + арифметика)";

        string ITask.Description => "Что сделать: найти сумму цифр введённого числа (например, 1234 → 10).";

        string[] ITask.Requirements => new[] { "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.", "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.", "Оба способа оформить отдельными методами.", "Отрицательные числа — брать модуль." };


        void ITask.Run()
        {
            
            Console.WriteLine("Выберите вариант решения");
            int y = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            switch (y)
            {
                case 1:
                    Console.Write("Введите число: ");
                    string input = Console.ReadLine();
                    

                    foreach (char c in input)
                    {
                        if (char.IsDigit(c))
                            sum += int.Parse(c.ToString());
                    }

                    Console.WriteLine($"Сумма цифр: {sum}");
                    break;


                case 2:
                    Console.Write("Введите число: ");
                    int n = Math.Abs(int.Parse(Console.ReadLine()));

                    
                    while (n > 0)
                    {
                        sum += n % 10;
                        n /= 10;
                    }

                    Console.WriteLine($"Сумма цифр: {sum}");
                    break;

                default:
                    Console.WriteLine("Вариант не верный");
                    break;
            }

        }
    }
}
