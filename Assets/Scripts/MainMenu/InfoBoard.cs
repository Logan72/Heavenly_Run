using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoard : MonoBehaviour
{
    [SerializeField] TMP_Text armourTMP;
    [SerializeField] TMP_Text healingTMP;
    [SerializeField] TMP_Text speedTMP;
    [SerializeField] TMP_Text CGS_TMP;
    [SerializeField] TMP_Text specialSkillTMP;
    [SerializeField] CharacterSO[] characterSOs;
    [SerializeField] Transform characterContainer;
    GameObject character;

    void Start()
    {
        DisplayInfo(0);
    }

    public void DisplayInfo(int index)
    {  
        Destroy(character);
        character = Instantiate(characterSOs[index].CharacterPrefab, characterContainer);
        armourTMP.text = "Armor: " + characterSOs[index].Armour.ToString();
        healingTMP.text = "Healing: " + characterSOs[index].HealingSkill.ToString();
        speedTMP.text = "Speed L/R: " + characterSOs[index].LR_Speed.ToString();
        CGS_TMP.text = "Coin grabbing skill: " + characterSOs[index].CoinGrabbingSkill.ToString();
        specialSkillTMP.text = "Special skill: " + characterSOs[index].SpecialSkill;
    }
}
