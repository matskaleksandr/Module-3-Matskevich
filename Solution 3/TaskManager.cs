using System.Collections.Generic;

namespace Solution_3
{
    // Класс для управления задачами
    public class TaskManager
    {
        private List<TaskDelegate> taskDelegates = new List<TaskDelegate>();

        // Метод для добавления делегата для задачи
        public void AddTaskDelegate(TaskDelegate taskDelegate)
        {
            taskDelegates.Add(taskDelegate);
        }

        // Метод для выполнения задачи с использованием выбранного делегата
        public void ExecuteTask(string task)
        {
            foreach (var taskDelegate in taskDelegates)
            {
                taskDelegate.Invoke(task);
            }
        }
    }
}
