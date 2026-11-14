using CSharpPracticum.Common;
using CSharpPracticum.Figure;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 25)]
    internal class Task25_IShape : Common.ITask
    {
        string ITask.Title => "Интерфейс IShape + сортировка фигур";

        string ITask.Description => "Что сделать: реализовать интерфейс фигур и отсортировать их.";

        string[] ITask.Requirements => new[] { "IShape с методами Area() и Perimeter().", "Классы Circle, Rectangle, Triangle — реализуют IShape.", "Создать List<IShape> из 5+ фигур.", "Отсортировать по площади (через List.Sort с лямбдой или OrderBy)." };



        void ITask.Run()
        {
            var shapes = new List<IShape>
        {
            new Circle(2),           // S ≈ 12.57
            new Rectanglel(3, 4),     // S = 12
            new Triangle(3, 4, 5),   // S = 6
            new Circle(1),           // S ≈ 3.14
            new Rectanglel(5, 2),     // S = 10
            new Triangle(6, 8, 10)   // S = 24
        };

            Console.WriteLine("=== До сортировки ===");
            PrintShapes(shapes);

            // Сортировка по возрастанию площади
            shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));

            Console.WriteLine("\n=== После сортировки (по возрастанию площади) ===");
            PrintShapes(shapes);
        }

        static void PrintShapes(List<IShape> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1}. {list[i]}");
        }
    }
    }

