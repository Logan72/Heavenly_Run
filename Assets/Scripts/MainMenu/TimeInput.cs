using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeInput : MonoBehaviour
{
    public void ChangeInputFieldState(bool state)
    {
        GetComponent<TMP_InputField>().gameObject.SetActive(state);
    }
}
