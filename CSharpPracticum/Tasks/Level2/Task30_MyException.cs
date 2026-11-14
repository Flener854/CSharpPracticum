using System;
using System.Collections.Generic;
using System.Text;
using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 30)]
    internal class Task30_MyException : Common.ITask
    {
        string ITask.Title => "BankAccount + свой Exception";

        string ITask.Description => "Что сделать: реализовать банковский счёт с собственным исключением.";

        string[] ITask.Requirements => new[] { "Класс BankAccount с приватным балансом.", "Методы Deposit(decimal), Withdraw(decimal).", "Свой класс InsufficientFundsException : Exception.", "Withdraw бросает исключение, если сумма больше баланса.", "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)." };



        void ITask.Run()
        {
            var account = new BankAccount(1000m);
            Console.WriteLine($"Стартовый баланс: {account.Balance}");

            // Успешное снятие
            try
            {
                account.Withdraw(300m);
                Console.WriteLine($"Снято 300, баланс: {account.Balance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Попытка снять больше баланса
            try
            {
                account.Withdraw(5000m);
                Console.WriteLine($"Снято 5000, баланс: {account.Balance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Запрошено: {ex.Requested}, доступно: {ex.Available}");
            }

            // Проверка, что баланс не ушёл в минус
            Console.WriteLine($"Итоговый баланс: {account.Balance}");
        }
    }
}
