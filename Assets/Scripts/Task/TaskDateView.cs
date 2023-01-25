using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Task
{
    public class TaskDateView : MonoBehaviour
    {
        [SerializeField] private Image _dateIcon;
        [SerializeField] private TMP_Text _dateText;
        [SerializeField] private Color _datePassedColor;

        public void SetDate(string date)
        {
            if(string.IsNullOrEmpty(date))
            {
                _dateIcon.gameObject.SetActive(false);
                _dateText.gameObject.SetActive(false);
                return;
            }
            _dateText.text = date.Replace("/", ".");
            if (DateUtility.DateIsPassed(date))
            {
                _dateText.color = _datePassedColor;
                _dateIcon.color = _datePassedColor;
            }
        }
    }
}