using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class TaskCompleter : MonoBehaviour
    {
        [SerializeField] private Button _completeButton;

        public Action Completed;

        private void OnEnable()
        {
            _completeButton.onClick.AddListener(Click);
        }
        
        private void OnDisable()
        {
            _completeButton.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            Completed?.Invoke();
        }
    }
}