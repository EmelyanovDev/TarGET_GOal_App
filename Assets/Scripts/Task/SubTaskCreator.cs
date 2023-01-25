using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class SubTaskCreator : MonoBehaviour
    {
        [SerializeField] private Button _subPurposeButton;

        public event Action Clicked;

        private void OnEnable()
        {
            _subPurposeButton.onClick.AddListener(CreateSubPurpose);
        }
        
        private void OnDisable()
        {
            _subPurposeButton.onClick.RemoveListener(CreateSubPurpose);
        }

        private void CreateSubPurpose()
        {
            Clicked?.Invoke();
        }

        public void DisableButton()
        {
            _subPurposeButton.gameObject.SetActive(false);
        }
    }
}