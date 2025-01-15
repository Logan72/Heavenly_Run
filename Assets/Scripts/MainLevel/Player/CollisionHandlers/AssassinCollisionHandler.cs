using UnityEngine;

public class AssassinCollisionHandler : PlayerCollisionHandler
{
    [SerializeField] AssassinAudioManager assassinAudioManager;

    protected override void PlayHurtSFX()
    {
        assassinAudioManager.PlayHurtSFX();
    }

    protected override void PlayDyingSFX()
    {
        assassinAudioManager.PlayDyingSFX();
    }
}
