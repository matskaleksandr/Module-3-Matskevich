using System;

namespace Solution_1_Test
{
    class Triangle : Shape
    {
        private double dl1;//поле для хранения длины 1 стороны
        private string sl1;//поле для хранения строки 1 стороны
        private double dl2;//поле для хранения длины 2 стороны
        private string sl2;//поле для хранения строки 2 стороны
        private double dl3;//поле для хранения длины 3 стороны
        private string sl3;//поле для хранения строки 3 стороны
        //метод для вычисления площади прямоугольника
        public void Areas()
        {
            do
            {
                do
                {
                    Console.WriteLine("Введите длину 1 стороны:");//Вывод сообщения для пользователя о вводе длины
                    sl1 = Console.ReadLine();
                }
                while (!double.TryParse(sl1, out dl1));//Проверка что введенное значение является числом с плавающей запятой
            }
            while (dl1 < 0);//проверка что длина больше или равна нулю
            do
            {
                do
                {
                    Console.WriteLine("Введите длину 2 стороны:");//Вывод сообщения для пользователя о вводе длины
                    sl2 = Console.ReadLine();
                }
                while (!double.TryParse(sl2, out dl2));//Проверка что введенное значение является числом с плавающей запятой
            }
            while (dl3 < 0);//проверка что длина больше или равна нулю
            do
            {
                do
                {
                    Console.WriteLine("Введите длину 2 стороны:");//Вывод сообщения для пользователя о вводе длины
                    sl3 = Console.ReadLine();
                }
                while (!double.TryParse(sl3, out dl3));//Проверка что введенное значение является числом с плавающей запятой
            }
            while (dl3 < 0);//проверка что длина больше или равна нулю
            //вычисление площади прямоугольника и установка их в базовом классе Shape
            double PolPer = (dl1 + dl2 + dl3) / 2;
            base.Area_ = Math.Sqrt(PolPer * (PolPer - dl1) * (PolPer - dl2) * (PolPer - dl2));
        }
    }
}
