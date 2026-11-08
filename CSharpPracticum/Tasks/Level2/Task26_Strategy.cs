using CSharpPracticum.Common;
using CSharpPracticum.Calculat;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 26)]
    internal class Task26_Strategy : Common.ITask
    {
        string ITask.Title => "Паттерн «Стратегия» (скидки)";

        string ITask.Description => "Что сделать: реализовать калькулятор скидок через паттерн «Стратегия».";

        string[] ITask.Requirements => new[] { "Интерфейс IDiscountStrategy с методом Apply(decimal price).", "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%).", "Класс PriceCalculator, принимающий стратегию в конструкторе.", "Продемонстрировать расчёт цены с каждой стратегией." };



        void ITask.Run()
        {
            decimal price = 1000m;

            // Три стратегии — три калькулятора (или один с разными стратегиями)
            IDiscountStrategy[] strategies =
            {
            new NoDiscount(),
            new VipDiscount(),
            new PromoDiscount()
        };

            Console.WriteLine($"Исходная цена: {price:F2}\n");
            Console.WriteLine($"{"Стратегия",-20} {"Итоговая цена",15} {"Экономия",12}");
            Console.WriteLine(new string('-', 50));

            foreach (var strategy in strategies)
            {
                var calculator = new PriceCalculator(strategy);
                decimal final = calculator.Calculate(price);
                decimal saved = price - final;

                Console.WriteLine($"{strategy.Name,-20} {final,15:F2} {saved,12:F2}");
            }
        }
    }
    }

