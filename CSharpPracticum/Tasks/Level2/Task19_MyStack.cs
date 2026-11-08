using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 19)]
    internal class Task19_MyStack : Common.ITask
    {
        string ITask.Title => "Свой стек/очередь на массиве";

        string ITask.Description => "Что сделать: реализовать MyStack<T> и MyQueue<T> на массиве.";

        string[] ITask.Requirements => new[] { "Стек: Push, Pop, Peek, Count, IsEmpty.", "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty.", "При переполнении — расширять внутренний массив (удвоение).", "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException." };



        void ITask.Run()
        {
            // cтек 
            Console.WriteLine("=== MyStack ===");
            var stack = new MyStack<int>(2);    // маленькая ёмкость — проверим удвоение

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);                     // здесь сработает Resize: 2 → 4
            stack.Push(40);

            Console.WriteLine($"Count={stack.Count}, Peek={stack.Peek()}, IsEmpty={stack.IsEmpty}");
            Console.WriteLine($"Pop={stack.Pop()}");   // 40
            Console.WriteLine($"Pop={stack.Pop()}");   // 30
            Console.WriteLine($"Count={stack.Count}, Peek={stack.Peek()}"); // 2, 20
            Console.WriteLine($"Pop={stack.Pop()}");   // 20
            Console.WriteLine($"Pop={stack.Pop()}");   // 10
            Console.WriteLine($"IsEmpty={stack.IsEmpty}");

            try { stack.Pop(); }
            catch (InvalidOperationException ex) { Console.WriteLine($"Ожидаемо: {ex.Message}"); }

            // очередь 
            Console.WriteLine("\n=== MyQueue ===");
            var queue = new MyQueue<int>(2);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);                   // Resize: 2 → 4
            queue.Enqueue(4);

            Console.WriteLine($"Count={queue.Count}, Peek={queue.Peek()}, IsEmpty={queue.IsEmpty}");
            Console.WriteLine($"Dequeue={queue.Dequeue()}");   // 1
            Console.WriteLine($"Dequeue={queue.Dequeue()}");   // 2
            Console.WriteLine($"Count={queue.Count}, Peek={queue.Peek()}"); // 2, 3
            Console.WriteLine($"Dequeue={queue.Dequeue()}");   // 3
            Console.WriteLine($"Dequeue={queue.Dequeue()}");   // 4
            Console.WriteLine($"IsEmpty={queue.IsEmpty}");

            try { queue.Dequeue(); }
            catch (InvalidOperationException ex) { Console.WriteLine($"Ожидаемо: {ex.Message}"); }
        }
    }
}
