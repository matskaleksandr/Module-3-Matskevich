using System;

namespace Solution_1_Test
{
    class Rectangle : Shape
    {
        private double dLength;//поле для хранения длины прямоугольника
        private string sLength;//поле для хранения строки с введенной пользователем длиной
        private double dWidth;//поле для хранения ширины прямоугольника 
        private string sWidth;//поле для хранения строки с введенной пользователем шириной
        //метод для вычисления площади прямоугольника
        public void Areas()
        {
            do
            {
                do
                {
                    Console.WriteLine("Введите длину:");//Вывод сообщения для пользователя о вводе длины
                    sLength = Console.ReadLine();
                }
                while (!double.TryParse(sLength, out dLength)); // Проверяем, что введенное значение является числом с плавающей запятой
            }
            while (dLength < 0);//проверка что длина больше или равна нулю
            do
            {
                do
                {
                    Console.WriteLine("Введите ширину:");//Вывод сообщения для пользователя о вводе ширины
                    sWidth = Console.ReadLine();
                }
                while (!double.TryParse(sWidth, out dWidth));//проверка что введенное значение является числом с плавающей запятой
            }
            while (dWidth < 0);//проверка что ширина больше или равна нулю
            //вычисление площади прямоугольника и установка их в базовом классе Shape
            base.Area_ = dWidth * dLength;
        }
    }
}
