using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Tooltip("The value to add to chunks' speed.")]
    [SerializeField] float deltaSpeed;
    [SerializeField] Animator animator;
    const string hitTrigger = "Hit";
    [SerializeField] float coolDownTime;
    float coolDownTimer = 0f;

    void Update()
    {
        coolDownTimer += Time.deltaTime;        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (coolDownTimer > coolDownTime)
        {
            AudioManager.instance.PlayPlayerHurtSFX();
            animator.SetTrigger(hitTrigger);
            coolDownTimer = 0f;
            LevelGenerator.lvlGen.ChangeChunkMoveSpeed(deltaSpeed);
        }        
    }
}
