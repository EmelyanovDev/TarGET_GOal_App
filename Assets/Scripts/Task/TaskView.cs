using TMPro;
using UnityEngine;

namespace Task
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _purposeText;
        [SerializeField] private TaskDateView _dateView;
        [SerializeField] private ParticleSystem _completeParticle;

        private float _height;

        public float Height => _height;

        private void Awake()
        {
            _height = ((RectTransform)transform).sizeDelta.y;
        }

        public void Init(TaskInputData inputData)
        {
            _purposeText.text = inputData.PurposeText;
            _dateView.SetDate(inputData.PurposeDeadline);
        }

        public void CompleteEffect()
        {
            _completeParticle.Play();
        }
    }
}
