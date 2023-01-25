using System;

namespace Task
{
    [Serializable]
    
    public struct TaskData
    {
        public int ParentsCount;
        public TaskInputData InputData;

        public TaskData(TaskInputData inputData, int parentsCount)
        {
            ParentsCount = parentsCount;
            InputData = inputData;
        }
    }
}