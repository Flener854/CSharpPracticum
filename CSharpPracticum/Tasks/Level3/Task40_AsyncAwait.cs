using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 5)]
    internal class Task40_AsyncAwait:Common.ITask
    {
        string ITask.Title => "async/await + обработка исключений";

        string ITask.Description => "Что сделать: асинхронный метод с эмуляцией «скачивания».";

        string[] ITask.Requirements => new[] { "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000).", "Имитировать ошибку: если url пустой — бросить ArgumentException.", "В Main вызвать через await внутри try/catch.", "Продемонстрировать успешный и ошибочный вызов." };

        public static async Task<string> DownloadAsync(string url)
        {
            // Валидация аргументов
            if (string.IsNullOrWhiteSpace(url))
            {
                // В async-методах исключение автоматически "заворачивается" в Task,
                // но так как здесь нет await перед ним, оно может выброситься синхронно.
                // Тем не менее, await в вызывающем коде его поймает.
                throw new ArgumentException("URL не может быть пустым или null.", nameof(url));
            }

            Console.WriteLine($"[Download] Начинаем скачивание с {url}...");

            // Эмуляция долгой операции (1 секунда)
            await Task.Delay(1000);

            Console.WriteLine($"[Download] Скачивание завершено.");

            return $"Данные с {url} (размер: 1024 байта)";
        }

        public static async Task Ain()
        {
            Console.WriteLine("=== 1. Успешный вызов ===");
            try
            {
                string content = await DownloadAsync("https://example.com/data");
                Console.WriteLine($"Результат: {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка (сюда не попадём): {ex.GetType().Name}: {ex.Message}");
            }

            Console.WriteLine("\n=== 2. Ошибочный вызов (пустой URL) ===");
            try
            {
                // Исключение выбросится синхронно в начале метода, 
                // но await в try/catch корректно его перехватит
                string content = await DownloadAsync("");
                Console.WriteLine($"Результат (сюда не попадём): {content}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено ArgumentException: {ex.Message}");
                Console.WriteLine($"Параметр: {ex.ParamName}");
            }

            Console.WriteLine("\n=== 3. Ошибочный вызов (null URL) ===");
            try
            {
                string content = await DownloadAsync(null!);
                Console.WriteLine($"Результат (сюда не попадём): {content}");
            }
            catch (ArgumentException ex) // null тоже вызывает ArgumentException
            {
                Console.WriteLine($"Перехвачено ArgumentException: {ex.Message}");
            }

            Console.WriteLine("\n=== Приложение продолжает работу ===");
        }
        void ITask.Run()
        {
            Ain();
        }
    }
}
