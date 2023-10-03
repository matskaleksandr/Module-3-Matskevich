using System;
using System.Collections.Generic;

// Делегат для выполнения задачи 
delegate void TaskDelegate(string taskName);
namespace Solution_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                if (choice == "3")
                {
                    break;
                }

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Выберите действие для задачи:");
                        Console.WriteLine("1. Отправить уведомление");
                        Console.WriteLine("2. Записать в журнал");
                        string actionChoice = Console.ReadLine();
                        TaskDelegate taskDelegate = null;

                        switch (actionChoice)
                        {
                            case "1":
                                taskDelegate = SendNotification;
                                break;
                            case "2":
                                taskDelegate = WriteToLog;
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор действия.");
                                break;
                        }

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
                                task.TaskHandler(task.Name);
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
            Console.WriteLine($"Отправка уведомления для задачи '{taskName}'");
        }

        static void WriteToLog(string taskName)
        {
            Console.WriteLine($"Запись в журнал для задачи '{taskName}'");
        }
    }
}
