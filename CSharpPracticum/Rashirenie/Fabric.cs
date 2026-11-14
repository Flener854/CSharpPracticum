using CSharpPracticum.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class EmailNotification : INotification
    {
        public string Channel => "Email";
        public void Send(string message)
            => Console.WriteLine($"[Email] {message}");
    }

    public class SmsNotification : INotification
    {
        public string Channel => "SMS";
        public void Send(string message)
            => Console.WriteLine($"[SMS]   {message}");
    }

    public class PushNotification : INotification
    {
        public string Channel => "Push";
        public void Send(string message)
            => Console.WriteLine($"[Push]  {message}");
    }

   
    // 3. enum типов
    
    public enum NotificationType
    {
        Email,
        Sms,
        Push
    }

   
    // 4. Фабрика
    
    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type,
                         "Неизвестный тип уведомления")
            };
        }
    }
}
