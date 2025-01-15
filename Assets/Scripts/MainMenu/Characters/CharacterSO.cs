using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] float healingSkill;
    [SerializeField] float armour;
    [SerializeField] float lr_Speed;
    [SerializeField] float coinGrabbingSkill;
    [SerializeField] string specialSkill;

    public float LR_Speed { get { return lr_Speed; } }
    public float HealingSkill { get { return healingSkill; } }
    public float Armour { get { return armour; } }
    public float CoinGrabbingSkill { get { return coinGrabbingSkill; } }
    public string SpecialSkill { get { return specialSkill; } }
    public GameObject CharacterPrefab { get { return characterPrefab; } }
}