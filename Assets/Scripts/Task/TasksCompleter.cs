using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task
{
    public class TasksCompleter : MonoBehaviour
    {
        [SerializeField] private TasksCreator tasksCreator;
        [SerializeField] private TasksRow _tasksRow;
        
        private List<Task> _tasks = new List<Task>();
        
        private void OnEnable()
        {
            tasksCreator.TasksChanged += SetTasksList;
        }
        
        private void OnDisable()
        {
            tasksCreator.TasksChanged -= SetTasksList;
        }

        private void OnDestroy() => UnSubscribe();

        private void UnSubscribe()
        {
            foreach (var task in _tasks)
                task.Completed -= CompleteTask;
        }

        private void SetTasksList(List<Task> tasks)
        {
            UnSubscribe();
            _tasks = tasks;
            foreach (var task in tasks)
                task.Completed += CompleteTask;
        }

        private void CompleteTask(Task task)
        {
            DestroySubTasks(task);
            StartCoroutine(DestroyTask(task));
        }

        private IEnumerator DestroyTask(Task task)
        {
            task.Complete();
            yield return new WaitForSeconds(0.25f);
            _tasksRow.ShiftRowAfterTask(task, _tasks, ShiftType.Up);
            Destroy(task.gameObject);
            _tasks.Remove(task);
            tasksCreator.SetTasks(_tasks);
        }

        private void DestroySubTasks(Task task)
        {
            List<Task> deleteTasks = new List<Task>();
            int index = _tasks.IndexOf(task);
            for (int i = index + 1; i < _tasks.Count; i++)
            {
                if (_tasks[i].ParentsCount > task.ParentsCount)
                    deleteTasks.Add(_tasks[i]);
                else
                    break;
            }
            foreach (var deleteTask in deleteTasks)
                StartCoroutine(DestroyTask(deleteTask));
        }
    }
}