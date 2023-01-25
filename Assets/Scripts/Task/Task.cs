using System;
using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(TaskView))]
    [RequireComponent(typeof(SubTaskCreator))]
    [RequireComponent(typeof(TaskCompleter))]
    [RequireComponent(typeof(TaskAnimator))]
    
    public class Task : MonoBehaviour
    {
        [SerializeField] private TaskView _view;
        [SerializeField] private SubTaskCreator _subTaskCreator;
        [SerializeField] private TaskCompleter _completer;
        [SerializeField] private TaskAnimator _animator;

        private int _parentsCount;
        private TaskData _data;

        public Action<Task> SubTaskClicked;
        public Action<Task> Completed;
        
        public int ParentsCount => _parentsCount;
        public TaskData Data => _data;
        public float Height => _view.Height;

        private void OnEnable()
        {
            _subTaskCreator.Clicked += OnSubTaskClicked;
            _completer.Completed += OnTaskCompleted;
        }
        
        private void OnDisable()
        {
            _subTaskCreator.Clicked -= OnSubTaskClicked;
            _completer.Completed -= OnTaskCompleted;
        }

        private void OnSubTaskClicked()
        {
            SubTaskClicked?.Invoke(this);
        }

        private void OnTaskCompleted()
        {
            Completed?.Invoke(this);
        }

        public void Complete()
        {
            _animator.Complete();
            _view.CompleteEffect();
        }

        public void Init(TaskData data, bool disableButton)
        {
            if(disableButton)
                _subTaskCreator.DisableButton();
            _parentsCount = data.ParentsCount;
            _view.Init(data.InputData);
            _data = data;
        }
    }
}

