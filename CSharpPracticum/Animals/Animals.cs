using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Animals
{
    public abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        // Абстрактный метод 
        public abstract string MakeSound();

        // Переопределение ToString() 
        public override string ToString()
        {
            return $"{GetType().Name} по имени \"{Name}\" говорит: \"{MakeSound()}\"";
        }
    }

    
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override string MakeSound() => "Гав!";
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override string MakeSound() => "Мяу!";
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override string MakeSound() => "Чирик!";

        // Собственный метод, которого нет у других
        public void Fly()
        {
            Console.WriteLine($"{Name} летит!");
        }
    }
}
