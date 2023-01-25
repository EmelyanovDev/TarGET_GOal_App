using System;
using System.Collections.Generic;

namespace Task.Save
{
    [Serializable]

    public class TasksSaveData
    {
        public List<TaskData> TasksData = new List<TaskData>();

        public TasksSaveData()
        {
        }

        public TasksSaveData(List<Task> tasks)
        {
            foreach (var task in tasks)
                TasksData.Add(task.Data);
        }
    }
}