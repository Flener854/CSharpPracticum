using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class Temperature
    {
        private const decimal AbsoluteZeroCelsius = -273.15m;

        private decimal _celsius;

        public decimal Celsius
        {
            get => _celsius;
            set
            {
                if (value < AbsoluteZeroCelsius)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        $"Температура не может быть ниже абсолютного нуля ({AbsoluteZeroCelsius} °C)");

                _celsius = value;
            }
        }

       
        public decimal Fahrenheit => Celsius * 9m / 5m + 32m;

        public Temperature(decimal celsius = 0m)
        {
            Celsius = celsius; // конструктор тоже проходит через валидацию
        }
    }
}
