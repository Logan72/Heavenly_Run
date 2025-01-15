using TMPro;
using UnityEngine;

public class CollectedPotions : MonoBehaviour
{
    [SerializeField] float deltaHealthScale;
    TMP_Text potionsTMP;
    int potionsCount;
    public bool HaveAnyPotion { get { return potionsCount > 0 ? true : false; } }

    void Awake()
    {
        potionsTMP = GetComponent<TMP_Text>();
        potionsTMP.text = potionsCount.ToString();
    }
    
    public void ModifyPotionsCount(int number)
    {
        potionsCount += number;
        potionsTMP.text = potionsCount.ToString();
    }

    public int ModifyDeltaHealth(float deltaHealth)
    {
        if (HaveAnyPotion)
        {
            ModifyPotionsCount(-1);
            return Mathf.RoundToInt(deltaHealth * deltaHealthScale);
        }

        return Mathf.RoundToInt(deltaHealth);
    }
}
