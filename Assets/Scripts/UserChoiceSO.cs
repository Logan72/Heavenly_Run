using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newUserChoiceSO", menuName = "Scriptable Objects/UserChoiceSO")]
public class UserChoiceSO : ScriptableObject
{
    public int CharacterIndex {  get; set; }
    public int? Time {  get; set; }
}
