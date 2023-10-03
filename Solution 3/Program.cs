using System;

namespace Solution_3
{
    // Делегат для задачи
    public delegate void TaskDelegate(string task);

    public class Program
    {
        // Метод для отправки уведомления
        public static void SendNotification(string task)
        {
            Console.WriteLine("Отправка уведомления о выполнении задачи: " + task);
        }

        // Метод для записи в журнал
        public static void LogTask(string task)
        {
            Console.WriteLine("Задача ведения журнала: " + task);
        }

        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            // Добавление делегатов
            taskManager.AddTaskDelegate(SendNotification);
            taskManager.AddTaskDelegate(LogTask);
            taskManager.AddTaskDelegate(LogTask);

            // Пример задачи
            string task = "Полное задание";
    
            // Выполнение задачи с использованием добавленных делегатов
            taskManager.ExecuteTask(task);
        }
    }
}
