using System;
using System.Collections.Generic;

namespace Solution_4
{
    class Program
    {
        delegate bool DataFilterDelegate(DataItem data);
        static void Main(string[] args)
        {
            //создание списка для хранения элементов данных
            List<DataItem> dataList = new List<DataItem>();
            //создание списка для хранения фильтров
            List<DataFilterDelegate> filters = new List<DataFilterDelegate>();
            //бесконечный цикл для работы с меню
            while (true)
            {
                Console.WriteLine("1. Создать элемент");
                Console.WriteLine("2. Добавить фильтр по дате");
                Console.WriteLine("3. Добавить фильтр по ключевому слову");
                Console.WriteLine("4. Просмотреть результаты фильтрации");
                Console.WriteLine("5. Выйти");
                //получение выбора пользователя
                string choice = GetUserChoice(1, 5);
                //обработка выбора пользователя
                switch (choice)
                {
                    case "1":
                        CreateDataItem(dataList);
                        break;
                    case "2":
                        AddDateFilter(filters);
                        break;
                    case "3":
                        AddKeywordFilter(filters);
                        break;
                    case "4":
                        ViewFilteredResults(dataList, filters);
                        break;
                    case "5":
                        return;
                }
            }
        }
        static string GetUserChoice(int min, int max)//метод для получения выбора пользователя в заданном диапазоне
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
        static void CreateDataItem(List<DataItem> dataList)//метод для создания элемента данных и добавления его в список
        {
            Console.Write("Введите имя элемента: ");
            string name = Console.ReadLine();
            DateTime date;
            while (true)
            {
                Console.Write("Введите дату элемента (гггг-мм-дд): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                else
                    Console.WriteLine("Неверный формат даты. Попробуйте снова.");
            }
            DataItem newItem = new DataItem { Name = name, Date = date };
            dataList.Add(newItem);
            Console.WriteLine("Элемент данных успешно создан.");
        }
        static void AddDateFilter(List<DataFilterDelegate> filters)//метод для добавления фильтрации по дате
        {
            DateTime targetDate;
            while (true)
            {
                Console.Write("Введите целевую дату для фильтрации (гггг-мм-дд): ");
                if (DateTime.TryParse(Console.ReadLine(), out targetDate))
                    break;
                else
                    Console.WriteLine("Неверный формат даты. Попробуйте снова.");
            }
            //создание делегата для фильтрации по дате и добавление его в список фильтров
            DataFilterDelegate dateFilter = delegate (DataItem data)
            {
                return data.Date == targetDate;
            };
            filters.Add(dateFilter);
            Console.WriteLine("Фильтр по дате успешно добавлен.");
        }
        //метод для добавления фильтрации по ключевому слову
        static void AddKeywordFilter(List<DataFilterDelegate> filters)
        {
            Console.Write("Введите ключевое слово для фильтрации: ");
            string keyword = Console.ReadLine().ToLower();
            //создание делегата для фильтрации по ключевому слову и добавление его в список фильтров
            DataFilterDelegate keywordFilter = delegate (DataItem data)
            {
                return data.Name.ToLower().Contains(keyword);
            };
            filters.Add(keywordFilter);
            Console.WriteLine("Фильтр по ключевому слову успешно добавлен.");
        }
        static void ViewFilteredResults(List<DataItem> dataList, List<DataFilterDelegate> filters)//метод для просмотра результатов фильтрации
        {
            if (filters.Count == 0)
            {
                Console.WriteLine("Фильтры не заданы. Пожалуйста, добавьте фильтры.");
                return;
            }
            //применение фильтров к списку данных и вывод результатов фильтрации
            List<DataItem> filteredItems = ApplyFilters(dataList, filters);
            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredItems)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню.");
            Console.ReadLine();
        }
        static List<DataItem> ApplyFilters(List<DataItem> dataList, List<DataFilterDelegate> filters)//метод для применения фильтров к данным
        {
            List<DataItem> filteredItems = new List<DataItem>();
            foreach (var item in dataList)
            {
                bool passesAllFilters = true;
                //проверка элемента данных на соответствие всем фильтрам
                foreach (var filter in filters)
                {
                    if (!filter(item))
                    {
                        passesAllFilters = false;
                        break;
                    }
                }
                if (passesAllFilters)
                    filteredItems.Add(item);
            }
            return filteredItems;
        }
    }
}
