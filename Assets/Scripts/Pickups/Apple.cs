using UnityEngine;

public class Apple : Pickup
{
    [Tooltip("The value to add to Health.")]
    [SerializeField] int deltaHealth;
    AudioManager audioManager;
    Health health;

    public override void Init(LevelGenerator levelGenerator)
    {
        audioManager = levelGenerator.PropertyAudioManager;
        health = levelGenerator.PropertyHealth;
    }

    protected override void OnPickUp()
    {
        audioManager.PlayAppleSFX();
        health.ChangeHealth(deltaHealth);
    }
}
