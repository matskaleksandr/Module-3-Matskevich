namespace Solution_3
{
    class TaskItem
    {
        public string Name { get; set; }
        public TaskDelegate TaskHandler { get; set; }
        public TaskItem(string name, TaskDelegate taskHandler)
        {
            Name = name; TaskHandler = taskHandler;
        }
    }
}