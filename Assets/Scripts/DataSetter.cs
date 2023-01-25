using FantomLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class DataSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text _dateText;
    [SerializeField] private Button _button;

    private string _defaultText;
    private string _date;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _defaultText = _dateText.text;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeData);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeData);
    }

    private void ChangeData()
    {
        AndroidPlugin.ShowDatePickerDialog("", "dd/MM/yy", gameObject.name, nameof(SetData));
    }
    
    private void SetData(string date)
    {
        _date = date;
        string replaced = date.Replace("/", ".");
        _dateText.text = replaced;
    }

    public string GetData()
    {
        _dateText.text = _defaultText;
        return _date;
    }
}