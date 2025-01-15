using UnityEngine;

public class OnnaBugeishaController : JumperController
{
    [SerializeField] OnnaBugeishaAudioManager onnaBugeishaAudioManager;

    protected override void DoSpecial()
    {
        onnaBugeishaAudioManager.PlaySpecialSFX();
        base.DoSpecial();
    }
}
