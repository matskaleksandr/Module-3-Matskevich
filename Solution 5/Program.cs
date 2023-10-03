using System;
using System.Collections.Generic;

class Program
{
    delegate void SortDelegate(List<int> data);

    static void Main(string[] args)
    {
        List<int> dataList = new List<int>();
        SortDelegate sortMethod = null;

        while (true)
        {
            Console.WriteLine("1. Добавить число");
            Console.WriteLine("2. Выбрать метод сортировки");
            Console.WriteLine("3. Сортировать");
            Console.WriteLine("4. Выйти");

            string choice = GetUserChoice(1, 4);

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
                        sortMethod(dataList);
                        Console.WriteLine("Данные успешно отсортированы.");
                    }
                    break;

                case "4":
                    return;
            }
        }
    }

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

    static void QuickSort(List<int> data)
    {
        QuickSortRecursive(data, 0, data.Count - 1);
    }

    static void QuickSortRecursive(List<int> data, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(data, low, high);
            QuickSortRecursive(data, low, partitionIndex - 1);
            QuickSortRecursive(data, partitionIndex + 1, high);
        }
    }

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
        data[i + 1] = data[high];
        data[high] = temp2;

        return i + 1;
    }
}
