using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    public interface IDiscountStrategy
    {
        decimal Apply(decimal price);
        string Name { get; }
    }
}
