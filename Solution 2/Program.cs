using System;

namespace Solution_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Notification notification = new Notification();//создание объекта уведомлений
            NotificationHandler handler = new NotificationHandler();//создание объекта обработчика сообщений
            // Регистрация обработчиков событий
            notification.MessageNotification += handler.OnMessageReceived;
            notification.CallNotification += handler.OnCallReceived;
            notification.EmailNotification += handler.OnEmailReceived;
            // Отправка уведомлений
            notification.SendMessage("Привет:)");
            notification.MakeCall("+375445509552");
            notification.SendEmail("kokoseke06@gmail.com");
        }
    }
}