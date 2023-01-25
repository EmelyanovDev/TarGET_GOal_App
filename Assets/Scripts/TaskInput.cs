using Task;
using TMPro;
using UnityEngine;

public class TaskInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private DataSetter _dateSetter;

    public bool TextIsEmpty => _inputField.text == "";

    public TaskInputData GetInputData()
    {
        var data = new TaskInputData(_inputField.text, _dateSetter.GetData());
        _inputField.text = null;
        return data;
    }
}
