using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level3
{
    [Common.TaskInfoAttribute("Level-3", 7)]
    internal class Task42_CancellationToken : Common.ITask
    {
        string ITask.Title => "CancellationToken — отмена через 2 сек";

        string ITask.Description => "Что сделать: реализовать долгую операцию с поддержкой отмены.";

        string[] ITask.Requirements => new[] { "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз.", "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды.", "Обработать OperationCanceledException.", "Вывести «операция отменена»." };

        public static async Task LongOperationAsync(CancellationToken token)
        {
            Console.WriteLine("[Операция] Начало работы (10 шагов по 500 мс)...");

            for (int i = 1; i <= 10; i++)
            {
                // Передаём токен в Task.Delay. Если отмена произойдёт во время
                // ожидания, Task.Delay выбросит OperationCanceledException.
                await Task.Delay(500, token);

                // Дополнительная проверка на случай, если отмена пришла 
                // между итерациями (хотя Task.Delay с токеном обычно покрывает это)
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"[Операция] Шаг {i}/10 выполнен.");
            }

            Console.WriteLine("[Операция] Все шаги успешно завершены.");
        }

        public static async Task Dain()
        {
            Console.WriteLine("=== Запуск долгой операции ===");

            // 1. Создаём источник отмены
            using var cts = new CancellationTokenSource();

            // 2. Настраиваем автоматическую отмену через 2 секунды
            cts.CancelAfter(TimeSpan.FromSeconds(2));

            try
            {
                // 3. Запускаем операцию, передавая токен
                await LongOperationAsync(cts.Token);

                Console.WriteLine("Операция успешно завершилась (сюда не попадём).");
            }
            catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
            {
                // 4. Обрабатываем отмену
                Console.WriteLine("\n[ГЛАВНЫЙ ПОТОК] Перехвачено OperationCanceledException.");
                Console.WriteLine(">>> Операция отменена <<<");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("Приложение продолжает работу и не упало.");
        }

        void ITask.Run()
        {
            Dain();
        }
    }
}
