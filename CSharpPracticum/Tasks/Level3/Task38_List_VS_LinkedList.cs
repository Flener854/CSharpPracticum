using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 3)]
    internal class Task38_List_VS_LinkedList : Common.ITask
    {
        string ITask.Title => "List < T > vs LinkedList<T>(бенчмарк)";

        string ITask.Description => "Что сделать: сравнить вставку в середину List<T> и LinkedList<T>.";

        string[] ITask.Requirements => new[] { "Создать List<int> и LinkedList<int> по 100 000 элементов.", "Вставить 1000 элементов в середину каждой коллекции.", "Замерить время через Stopwatch.", "Вывести оба времени и объяснить результат в комментарии." };

        private static LinkedListNode<int> GetMiddleNode(LinkedList<int> list)
        {
            var current = list.First;
            for (int i = 0; i < list.Count / 2 && current != null; i++)
                current = current.Next;
            return current!;
        }

        void ITask.Run()
        {
            const int initialSize = 100_000;
            const int insertCount = 1_000;

            
            var list = new List<int>(initialSize);
            for (int i = 0; i < initialSize; i++) list.Add(i);

           
            var linkedList = new LinkedList<int>();
            for (int i = 0; i < initialSize; i++) linkedList.AddLast(i);

           
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < insertCount; i++)
            {
                // Вставка ровно в середину
                list.Insert(list.Count / 2, -1);
            }
            sw.Stop();
            var listTime = sw.ElapsedMilliseconds;

            // Находим узел в середине ОДИН раз, чтобы показать преимущество O(1) вставки
            var middleNode = GetMiddleNode(linkedList);

            sw.Restart();
            for (int i = 0; i < insertCount; i++)
            {
                linkedList.AddBefore(middleNode, -1); // O(1)
            }
            sw.Stop();
            var linkedListTime = sw.ElapsedMilliseconds;

            
            Console.WriteLine($"Начальный размер: {initialSize:N0}");
            Console.WriteLine($"Количество вставок: {insertCount:N0} (в середину)");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"List<int>:       {listTime,5} мс (Итоговый размер: {list.Count:N0})");
            Console.WriteLine($"LinkedList<int>: {linkedListTime,5} мс (Итоговый размер: {linkedList.Count:N0})");
        }
    }
}
