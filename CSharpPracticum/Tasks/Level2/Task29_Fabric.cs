using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 29)]
    internal class Task29_Fabric : Common.ITask
    {
        string ITask.Title => "Паттерн «Фабрика» (уведомления)";

        string ITask.Description => "Что сделать: реализовать фабрику уведомлений.";

        string[] ITask.Requirements => new[] { "Интерфейс INotification с методом Send(string message).", "Реализации: EmailNotification, SmsNotification, PushNotification.", "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.", "enum NotificationType { Email, Sms, Push }." };



        void ITask.Run()
        {
            string message = "Ваш заказ №123 готов к выдаче.";

            NotificationType[] types =
            {
            NotificationType.Email,
            NotificationType.Sms,
            NotificationType.Push
        };

            Console.WriteLine($"Сообщение: \"{message}\"\n");

            foreach (NotificationType type in types)
            {
                // Фабрика решает, какой класс создать
                INotification notification = NotificationFactory.Create(type);

                Console.WriteLine($"Тип: {type,-5} → класс: {notification.GetType().Name}");
                notification.Send(message);
                Console.WriteLine();
            }
        }
    }
}
