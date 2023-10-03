using System;
using System.Collections.Generic;

namespace Solution_5
{
    class Program
    {
        delegate void SortDelegate(List<int> data);//определение делегата для сортировки

        static void Main(string[] args)
        {
            //создание списка для хранения чисел
            List<int> dataList = new List<int>();
            //инициализация делегата метода сортировки
            SortDelegate sortMethod = null;
            while (true)
            {
                Console.WriteLine("1. Добавить число");
                Console.WriteLine("2. Выбрать метод сортировки");
                Console.WriteLine("3. Сортировать");
                Console.WriteLine("4. Выйти");
                //получение выбора пользователя
                string choice = GetUserChoice(1, 4);
                //обработка выбора пользователя
                switch (choice)
                {
                    case "1":
                        AddNumber(dataList);
                        break;
                    case "2":
                        sortMethod = SelectSortMethod();
                        break;
                    case "3":
                        if (sortMethod == null)
                        {
                            Console.WriteLine("Метод сортировки не выбран. Пожалуйста, выберите метод сортировки.");
                        }
                        else
                        {
                            Console.WriteLine("Данные перед сортировкой:");
                            PrintArray(dataList);
                            //вызов выбранного метода сортировки
                            sortMethod(dataList);
                            Console.WriteLine("Данные после сортировки:");
                            PrintArray(dataList);
                        }
                        break;
                    case "4":
                        return;
                }
            }
        }
        //метод для получения выбора пользователя в заданном диапазоне
        static string GetUserChoice(int min, int max)
        {
            string input;
            int choice;
            do
            {
                Console.Write("Введите выбор: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out choice) || choice < min || choice > max);

            return input;
        }
        //метод для вывода массива чисел
        static void PrintArray(List<int> data)
        {
            foreach (var item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //метод для добавления числа в список
        static void AddNumber(List<int> dataList)
        {
            int number;
            Console.Write("Введите число: ");

            if (int.TryParse(Console.ReadLine(), out number))
            {
                dataList.Add(number);
                Console.WriteLine("Число успешно добавлено.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите корректное число.");
            }
        }
        //метод для выбора метода сортировки
        static SortDelegate SelectSortMethod()
        {
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Быстрая сортировка");
            string choice = GetUserChoice(1, 2);
            switch (choice)
            {
                case "1":
                    return BubbleSort;

                case "2":
                    return QuickSort;

                default:
                    return null;
            }
        }
        //метод для сортировки методом пузырька
        static void BubbleSort(List<int> data)
        {
            int n = data.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
        //метод для быстрой сортировки
        static void QuickSort(List<int> data)
        {
            QuickSortRecursive(data, 0, data.Count - 1);
        }
        //рекурсивный метод для быстрой сортировки
        static void QuickSortRecursive(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(data, low, high);
                QuickSortRecursive(data, low, partitionIndex - 1);
                QuickSortRecursive(data, partitionIndex + 1, high);
            }
        }
        //метод для разделения массива в быстрой сортировке
        static int Partition(List<int> data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
            int temp2 = data[i + 1];
            data[i + 1] = temp2;
            return i + 1;
        }
    }
}
