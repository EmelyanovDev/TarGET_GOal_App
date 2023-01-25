using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(Animator))]
    
    public class TaskAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Complete()
        {
            _animator.Play("TaskCompleting");   
        }
    }
}