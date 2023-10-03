using System;

namespace Solution_1_Test
{
    class Circle : Shape
    {
        private double dRadius;//поле для хранения радиуса круга
        private string sRadius;//поле для хранения строки с введенным пользователем радиусом
        // Метод для вычисления площади круга
        public void Areas()
        {
            do
            {
                do
                {
                    Console.WriteLine("Введите радиус:");//выводим сообщение для пользователя о вводе радиуса
                    sRadius = Console.ReadLine();//считывание введенного пользователем радиуса в виде строки
                }
                while (!double.TryParse(sRadius, out dRadius));//проверка что введенное значение является числом с плавающей запятой
            }
            while (dRadius < 0);//приверка что радиус больше или равен нулю
            //вычисление площади круга и устанавка их в базовом классе Shape
            base.Area_ = Math.PI * dRadius * dRadius;
        }
    }
}
