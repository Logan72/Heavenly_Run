using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserChoiceSetter : MonoBehaviour
{
    [SerializeField] TMP_Dropdown charactersDropdown;
    [SerializeField] Toggle timeToggle;
    [SerializeField] TMP_InputField time_InputField;
    [SerializeField] UserChoiceSO userChoiceSO;

    public void SetChoice()
    {
        userChoiceSO.CharacterIndex = charactersDropdown.value;

        if (timeToggle.isOn)
        {
            try
            {
                userChoiceSO.Time = int.Parse(time_InputField.text);
            }
            catch
            {
                userChoiceSO.Time = 0;
            }
        }
        else
        {
            userChoiceSO.Time = null;
        }
    }
}
