using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class InsufficientFundsException : Exception
    {
        public decimal Requested { get; }
        public decimal Available { get; }

        public InsufficientFundsException(decimal requested, decimal available)
            : base($"Недостаточно средств: запрошено {requested}, доступно {available}")
        {
            Requested = requested;
            Available = available;
        }
    }
}
