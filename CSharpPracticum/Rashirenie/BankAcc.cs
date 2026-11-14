using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance => _balance;

        public BankAccount(decimal initialBalance = 0)
        {
            if (initialBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Начальный баланс не может быть отрицательным");
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма пополнения должна быть положительной");
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма снятия должна быть положительной");

            if (amount > _balance)
                throw new InsufficientFundsException(amount, _balance);

            _balance -= amount;
        }
    }
}
