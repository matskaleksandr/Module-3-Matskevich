using System;
using System.Collections.Generic;

namespace Solution_3
{
    delegate void TaskDelegate(string taskName);

    class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();//создание списка для хранения задач
            //бесконечный цикл для взаимодействия с пользователем
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выход");

                string text = Console.ReadLine();//ввод пользователя

                //проверка на выход из программы
                if (text == "3")
                {
                    break;
                }
                switch (text)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();//считывание ввода пользователя
                        Console.WriteLine("Выберите действие для задачи:"); 
                        Console.WriteLine("1. Отправить уведомление");
                        Console.WriteLine("2. Записать в журнал");
                        string actionChoice = Console.ReadLine();//считывание ввода пользователя
                        TaskDelegate taskDelegate = null;//инициализация делегата обработчика задачи

                        switch (actionChoice)
                        {
                            case "1":
                                taskDelegate = SendNotification;//устанавливаем обработчик задачи
                                break;
                            case "2":
                                taskDelegate = WriteToLog;//устанавливаем обработчик задачи
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор действия.");
                                break;
                        }

                        //добавляем задачу в список, если установлен обработчик
                        if (taskDelegate != null)
                        {
                            tasks.Add(new TaskItem(taskName, taskDelegate));
                            Console.WriteLine($"Задача '{taskName}' добавлена.");
                        }
                        break;

                    case "2":
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Нет задач для выполнения.");
                        }
                        else
                        {
                            foreach (var task in tasks)
                            {
                                Console.WriteLine($"Выполнение задачи: {task.Name}");
                                task.TaskHandler(task.Name);//вызываем обработчик задачи
                                Console.WriteLine();
                            }
                            tasks.Clear();
                        }
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие из списка.");
                        break;
                }
            }
        }
        static void SendNotification(string taskName)
        {
            Console.WriteLine($"Отправка уведомления для задачи '{taskName}'");  // Выводим сообщение в консоль
        }
        static void WriteToLog(string taskName)
        {
            Console.WriteLine($"Запись в журнал для задачи '{taskName}'");  // Выводим сообщение в консоль
        }
    }
}
