using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] int health;
    [SerializeField] float armour;
    [SerializeField] string speed;
    [SerializeField] string specialSkill;

    public GameObject CharacterPrefab { get { return characterPrefab; } }
    public int Health { get { return health; } }
    public float Armour { get { return armour; } }
    public string Speed { get { return speed; } }
    public string SpecialSkill { get { return specialSkill; } }
}