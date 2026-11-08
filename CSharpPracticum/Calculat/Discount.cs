using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Calculat
{ 
        public class NoDiscount : IDiscountStrategy
        {
            public string Name => "Без скидки";
            public decimal Apply(decimal price) => price;
        }

        public class VipDiscount : IDiscountStrategy
        {
            public string Name => "VIP-скидка 10%";
            public decimal Apply(decimal price) => price * 0.90m;
        }

        public class PromoDiscount : IDiscountStrategy
        {
            public string Name => "Промо-скидка 20%";
            public decimal Apply(decimal price) => price * 0.80m;
        }

        
        public class PriceCalculator
        {
            private readonly IDiscountStrategy _strategy;

            public PriceCalculator(IDiscountStrategy strategy)
            {
                _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            }

            public decimal Calculate(decimal price)
            {
                if (price < 0) throw new ArgumentException("Цена не может быть отрицательной", nameof(price));
                return _strategy.Apply(price);
            }

            
            public IDiscountStrategy Strategy => _strategy;
        }
}

