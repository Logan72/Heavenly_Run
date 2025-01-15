using UnityEngine;

public class KnightCollisionHandler : PlayerCollisionHandler
{
    [SerializeField] KnightAudioManager knightAudioManager;

    protected override void PlayHurtSFX()
    {
        knightAudioManager.PlayHurtSFX();
    }

    protected override void PlayDyingSFX()
    {
        knightAudioManager.PlayDyingSFX();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (animator.GetBool(PlayerController.specialParameter))
        {
            NewMethod1(collision, NewMethod);
        }
        else
        {
            base.OnCollisionEnter(collision);
        }
    }

    void NewMethod(Collision collision)
    {
        knightAudioManager.PlayBlockingSFX();
    }
}
