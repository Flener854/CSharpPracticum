using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1",10)]
    internal class Task10_SortPuziric : Common.ITask
    {
        string ITask.Title => "Сортировка пузырьком + вставками";

        string ITask.Description => "Что сделать: отсортировать массив двумя алгоритмами.";

        string[] ITask.Requirements => new[] { "Реализовать BubbleSort и InsertionSort отдельными методами.", "Оба — без LINQ и Array.Sort.", "Замерить время каждого через Stopwatch на массиве 10 000 элементов.", "Вывести оба времени."};


        void ITask.Run()
        {
            const int size = 10_000;

            
            int[] original = new int[size];
            Random rnd = new Random(42);              
            for (int i = 0; i < size; i++)
                original[i] = rnd.Next(1, 100_001);

            
            int[] forBubble = (int[])original.Clone();
            int[] forInsertion = (int[])original.Clone();

            
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(forBubble);
            sw.Stop();
            TimeSpan bubbleTime = sw.Elapsed;

            
            sw.Restart();
            InsertionSort(forInsertion);
            sw.Stop();
            TimeSpan insertionTime = sw.Elapsed;

            
            Console.WriteLine($"BubbleSort:    {bubbleTime.TotalMilliseconds:F2} мс");
            Console.WriteLine($"InsertionSort: {insertionTime.TotalMilliseconds:F2} мс");

            
            Console.WriteLine($"Отсортированы одинаково: {AreEqual(forBubble, forInsertion)}");
            Console.WriteLine($"Отсортированы корректно:  {IsSorted(forBubble) && IsSorted(forInsertion)}");
        }

        
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;                 
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);   
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        
        static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
                if (arr[i - 1] > arr[i]) return false;
            return true;
        }

        static bool AreEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
    }
    }

