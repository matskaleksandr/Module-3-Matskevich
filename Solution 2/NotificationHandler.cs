using System;

namespace Solution_2
{
    class NotificationHandler
    {
        
        public void OnMessageReceived(object sender, string message)//метод для обработки события получения сообщения
        {
            Console.WriteLine("Получено сообщение: " + message);
        }
        public void OnCallReceived(object sender, string phoneNumber)//метод для обработки события получения звонка
        {
            Console.WriteLine("Входящий звонок от: " + phoneNumber);
        }
        public void OnEmailReceived(object sender, string emailAddress)//метод для обработки события получения электронного письма
        {
            Console.WriteLine("Получено сообщение от: " + emailAddress);
        }
    }
}