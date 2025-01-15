using Unity.Cinemachine;
using UnityEngine;

public class Setup : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameObject[] characterPrefabs;
    [SerializeField] CollectedPotions collectedPotions;
    [SerializeField] SpecialSkill specialSkill;
    [SerializeField] Health health;
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] GameManager gameManager;
    [SerializeField] UserChoiceSO userChoiceSO;

    void Start()
    {
        var character = Instantiate(characterPrefabs[userChoiceSO.CharacterIndex], Vector3.zero, Quaternion.identity);
        PlayerCollisionHandler pch = character.GetComponentInChildren<PlayerCollisionHandler>();
        PlayerController pc = pch.GetComponent<PlayerController>();

        pch.Init(collectedPotions, health);
        pc.Init(specialSkill);
        gameManager.Init(pc);
        cinemachineCamera.Target.TrackingTarget = pch.GetComponentInChildren<Animator>().transform;
        timer.Init(userChoiceSO.Time);
    }
}
