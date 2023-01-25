using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Task.Save
{
    public class TasksSaver : MonoBehaviour
    {
        [SerializeField] private TasksCreator _creator;
        
        private string _jsonPath;

        private void Awake()
        {
            _jsonPath = Application.persistentDataPath + "/Save.json";
        }

        private void OnEnable()
        {
            _creator.TasksChanged += Save;
        }
        
        private void OnDisable()
        {
            _creator.TasksChanged -= Save;
        }

        private void Save(List<Task> tasks)
        {
            var data = new TasksSaveData(tasks);
            var jsonData = JsonUtility.ToJson(data);
            File.WriteAllText(_jsonPath, jsonData);
        }

        public TasksSaveData Load()
        {
            if (File.Exists(_jsonPath) == false)
                return new TasksSaveData();
            string data = File.ReadAllText(_jsonPath);
            return JsonUtility.FromJson<TasksSaveData>(data);
        }
    }
}