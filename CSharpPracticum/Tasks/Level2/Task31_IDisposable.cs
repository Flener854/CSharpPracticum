using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 31)]
    internal class Task31_IDisposable : Common.ITask
    {
        string ITask.Title => "IDisposable + using";

        string ITask.Description => "Что сделать: реализовать IDisposable для класса, работающего с файлом.";

        string[] ITask.Requirements => new[] { "Класс FileWriter с полем StreamWriter.", "Реализовать Dispose() (закрыть StreamWriter).", "Продемонстрировать использование через using.", "Дополнительно: продемонстрировать using-декларацию(C# 8+, using var)." };

        private static void WriteMore(string path)
        {
            using var fw = new FileWriter(path); 
            fw.WriteLine("Строка A");
            fw.WriteLine("Строка B");
        } 

        void ITask.Run()
        {
            string path = "log.txt";

            
            using (var fw = new FileWriter(path))
            {
                fw.WriteLine("Строка 1");
                fw.WriteLine("Строка 2");
            } 

            
            WriteMore(path);

            // 3) Проверка: файл закрыт, можем открыть и дописать
            using (var appendWriter = new StreamWriter(path, append: true))
            {
                appendWriter.WriteLine("Строка из другой программы");
            }

            Console.WriteLine("Файл закрыт корректно, повторная запись не упала.");
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(File.ReadAllText(path));

            
            var disposed = new FileWriter("tmp.txt");
            disposed.Dispose();
            try
            {
                disposed.WriteLine("не должно записаться");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"Ожидаемое исключение: {ex.ObjectName} уже освобождён");
            }
        }
    }
}
