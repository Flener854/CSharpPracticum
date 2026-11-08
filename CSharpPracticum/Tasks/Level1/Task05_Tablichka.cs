using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task05_Tablichka : Common.ITask
    {
        string ITask.Title => "Таблица умножения 10×10";

        string ITask.Description => "Что сделать: вывести таблицу умножения 10×10.";

        string[] ITask.Requirements => new[] { "Использовать вложенные циклы for.", "Выровнять столбцы", "Заголовки строк/столбцов — не обязательны, но приветствуются."};


        void ITask.Run()
        {
            for(int i = 0; i <= 10; i++) 
            { 
                for(int j = 0; j <= 10; j++) 
                {
                    Console.Write($"{i*j,4}");
                }
                Console.WriteLine();
            } 
        }
    }
}
