using CSharpPracticum.Common;
using CSharpPracticum.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2.Task24_animals
{
    [Common.TaskInfoAttribute("Level-2", 24)]
    internal class Task24_DogCatBird : Common.ITask
    {
        string ITask.Title => "ООП: Animal → Dog/Cat/Bird";

        string ITask.Description => "Что сделать: построить иерархию животных.";

        string[] ITask.Requirements => new[] { "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().", "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().", "Bird дополнительно имеет метод Fly().", "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле." };



        void ITask.Run()
        {

            var animals = new List<Animal>
            {
                new Dog("Шарик"),
                new Cat("Мурка"),
                new Bird("Кеша"),
                new Dog("Бобик"),
                new Cat("Барсик")
            };

            Console.WriteLine(" Полиморфизм: List<Animal>, вызов MakeSound() ");
            foreach (Animal animal in animals)
            {
                // Вызывается ПЕРЕОПРЕДЕЛЁННЫЙ MakeSound() конкретного типа
                Console.WriteLine($"{animal.Name} ({animal.GetType().Name}): {animal.MakeSound()}");
            }

            Console.WriteLine("\n ToString() ");
            foreach (Animal animal in animals)
                Console.WriteLine(animal.ToString());

            Console.WriteLine("\n Bird.Fly() — только у птиц ");
            foreach (Animal animal in animals)
            {
                // Fly() есть только у Bird — нужен pattern matching
                if (animal is Bird bird)
                    bird.Fly();
                else
                    Console.WriteLine($"{animal.Name} ({animal.GetType().Name}) не умеет летать.");
            }
        }
    }
}
