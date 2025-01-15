using UnityEngine;

public class KnightController : ContinuousSpecialController
{
    [SerializeField] KnightAudioManager knightAudioManager;

    protected override void DoSpecial()
    {
        knightAudioManager.PlaySpecialSFX();
        base.DoSpecial();
    }
}
