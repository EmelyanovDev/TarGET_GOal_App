using System;

namespace Task
{
    [Serializable]
    
    public struct TaskInputData
    {
        public string PurposeText;
        public string PurposeDeadline;

        public TaskInputData(string purposeText, string purposeDeadline)
        {
            PurposeText = purposeText;
            PurposeDeadline = purposeDeadline;
        }
    }
}