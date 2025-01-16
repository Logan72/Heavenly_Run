using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoard : MonoBehaviour
{
    [SerializeField] CharacterSO[] characterSOs;
    [SerializeField] TMP_Text healthTMP;
    [SerializeField] TMP_Text armourTMP;
    [SerializeField] TMP_Text speedTMP;
    [SerializeField] TMP_Text specialSkillTMP;
    [SerializeField] Transform characterContainer;
    GameObject currentCharacter;

    void Start()
    {
        DisplayInfo(0);
    }

    public void DisplayInfo(int index)
    {  
        Destroy(currentCharacter);
        currentCharacter = Instantiate(characterSOs[index].CharacterPrefab, characterContainer);
        healthTMP.text = "Health: " + characterSOs[index].Health.ToString();
        armourTMP.text = "Armour: " + characterSOs[index].Armour.ToString() + " %";
        speedTMP.text = "Speed: " + characterSOs[index].Speed.ToString();
        specialSkillTMP.text = "Special ability: " + characterSOs[index].SpecialSkill;
    }
}
