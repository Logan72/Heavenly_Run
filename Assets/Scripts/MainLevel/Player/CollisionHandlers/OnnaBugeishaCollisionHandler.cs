using UnityEngine;

public class OnnaBugeishaCollisionHandler : PlayerCollisionHandler
{
    [SerializeField] OnnaBugeishaAudioManager onnaBugeishaAudioManager;

    protected override void PlayHurtSFX()
    {
        onnaBugeishaAudioManager.PlayHurtSFX();
    }

    protected override void PlayDyingSFX()
    {
        onnaBugeishaAudioManager.PlayDyingSFX();
    }
}
