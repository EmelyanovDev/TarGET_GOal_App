using System.Collections.Generic;
using UnityEngine;

namespace Task
{
    public class TasksRow : MonoBehaviour
    {
        [SerializeField] private float _yOffset;

        private int _referenceHeight = 1920;
        
        public float YOffset => _yOffset;

        private void Awake()
        {
            _yOffset = _yOffset * Screen.height / _referenceHeight;
        }

        public void ShiftRowAfterTask(Task task, List<Task> tasks, ShiftType shiftType)
        {
            int index = tasks.IndexOf(task);
            for (int i = index + 1; i < tasks.Count; i++)
                tasks[i].transform.Translate(0, _yOffset * (float)shiftType, 0);
        }
        
        public void ShiftRowAfterTask(int taskIndex, List<Task> tasks, ShiftType shiftType)
        {
            for (int i = taskIndex; i < tasks.Count; i++)
                tasks[i].transform.Translate(0, _yOffset * (float)shiftType, 0);
        }
    }
}