using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(RectTransform))]
    
    public class TasksContentSize : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TasksCreator _tasksCreator;
        [SerializeField] private float _sizeOffsetY;
        [SerializeField] private float _xMultiplier;

        private int _maxParentsCount;
        private float _sizeOffsetsX;

        private void Start()
        {
            _sizeOffsetsX = _tasksCreator.XOffset;
        }

        private void OnEnable()
        {
            _tasksCreator.TasksChanged += ChangeSize;
        }
        
        private void OnDisable()
        {
            _tasksCreator.TasksChanged -= ChangeSize;
        }

        private void ChangeSize(List<Task> tasks)
        {
            int maxParentsCount = tasks.Select(task => task.ParentsCount).Prepend(0).Max();
            var delta = _rectTransform.sizeDelta;
            delta.y = tasks.Sum(task => task.Height) + _sizeOffsetY * tasks.Count + 250;
            delta.x = Mathf.Max(maxParentsCount, 0) * _sizeOffsetsX * _xMultiplier;
            _rectTransform.sizeDelta = delta;
        }
    }
}