using System;

namespace Solution_2
{
    class Notification
    {
        public event EventHandler<string> MessageNotification;//cобытие для сообщений
        public event EventHandler<string> CallNotification;//cобытие для звонков
        public event EventHandler<string> EmailNotification;//cобытие для электронных писем
        public void SendMessage(string message)//метод для отправки сообщения
        {
            MessageNotification?.Invoke(this, message);
        }
        public void MakeCall(string phoneNumber)//метод для совершения звонка
        {
            CallNotification?.Invoke(this, phoneNumber);
        }
        public void SendEmail(string emailAddress)//метод для отправки электронного письма
        {
            EmailNotification?.Invoke(this, emailAddress);
        }
    }
}
