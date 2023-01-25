using System;
using System.Collections.Generic;
using Task.Save;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class TasksCreator : MonoBehaviour
    {
        [SerializeField] private Task _template;
        [SerializeField] private TasksRow _tasksRow;
        [SerializeField] private Button _createButton;
        [SerializeField] private TaskInput _taskInput;
        [SerializeField] private Transform _content;
        [SerializeField] private float _xOffset;
        [SerializeField] private int _maxParentsCount;
        
        private float _tasksYOffset;
        private List<Task> _tasks = new List<Task>();
        private int _referenceHeight = 1920;

        public Action<List<Task>> TasksChanged;
        public float XOffset => _xOffset;

        private void Awake()
        {
            _xOffset = _xOffset * Screen.height / _referenceHeight;
        }

        private void Start()
        {
            _tasksYOffset = _tasksRow.YOffset;
        }

        private void OnEnable() 
        {
            _createButton.onClick.AddListener(CreateTask);
        }

        private void OnDisable() 
        {
            _createButton.onClick.RemoveListener(CreateTask);
        }

        private void CreateTask()
        {
            if (_taskInput.TextIsEmpty) return;
            
            var newTask = Instantiate(_template, _content);
            var data = new TaskData(_taskInput.GetInputData(), 0);
            newTask.Init(data, false);
            newTask.transform.Translate(0, -_tasksYOffset * _tasks.Count, 0);
            _tasks.Add(newTask);
            TasksChanged?.Invoke(_tasks);
            newTask.SubTaskClicked += CreateSubTask;
        }
        
        public void CreateTask(TaskData data)
        {
            var newTask = Instantiate(_template, _content);
            newTask.Init(data, data.ParentsCount >= _maxParentsCount);
            newTask.transform.Translate(_xOffset * data.ParentsCount, -_tasksYOffset * _tasks.Count, 0);
            
            _tasks.Add(newTask);
            TasksChanged?.Invoke(_tasks);
            newTask.SubTaskClicked += CreateSubTask;
        }
        
        private void CreateSubTask(Task parentTask)
        {
            if (_taskInput.TextIsEmpty) return;
            
            var newTask = Instantiate(_template, _content);
            int parentsCount = parentTask.ParentsCount + 1;
            var data = new TaskData(_taskInput.GetInputData(), parentsCount);
            newTask.Init(data, parentsCount >= _maxParentsCount);
            int taskIndex = _tasks.IndexOf(parentTask) + 1;
            _tasksRow.ShiftRowAfterTask(taskIndex, _tasks, ShiftType.Down);
            TranslateSubTask(newTask, taskIndex);
            _tasks.Insert(taskIndex, newTask);
            TasksChanged?.Invoke(_tasks);
            newTask.SubTaskClicked += CreateSubTask;
        }
        
        private void TranslateSubTask(Task task, int index)
        {
            Vector3 position = new Vector3(_xOffset * task.ParentsCount, -_tasksYOffset * index, 0);
            task.transform.Translate(position);
        }

        public void SetTasks(List<Task> tasks)
        {
            _tasks = tasks;
            TasksChanged?.Invoke(tasks);
        }
    }
}
