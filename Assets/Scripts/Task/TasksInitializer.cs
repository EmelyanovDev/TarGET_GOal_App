using System.Collections;
using Task.Save;
using UnityEngine;

namespace Task
{
    public class TasksInitializer : MonoBehaviour
    {
        [SerializeField] private TasksSaver _saver;
        [SerializeField] private TasksCreator _creator;
         
        private void Start()
        {
            StartCoroutine(InitTasks());
        }
        
        private IEnumerator InitTasks()
        {
            yield return new WaitForEndOfFrame();
            var data = _saver.Load();
            foreach (var task in data.TasksData)
                _creator.CreateTask(task);
        }
    }
}