using UnityEngine;

public class Potion : Pickup
{
    AudioManager audioManager;
    CollectedPotions potionsManager;

    public override void Init(LevelGenerator levelGenerator)
    {
        audioManager = levelGenerator.PropertyAudioManager;
        potionsManager = levelGenerator.PotionsManager;
    }

    protected override void OnPickUp()
    {
        audioManager.PlayPotionSFX();
        potionsManager.ModifyPotionsCount(1);
    }
}
