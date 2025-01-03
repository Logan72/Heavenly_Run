using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] float scoreToAdd;
    AudioManager audioManager;
    Score score;

    public override void Init(LevelGenerator levelGenerator)
    {
        audioManager = levelGenerator.PropertyAudioManager;
        score = levelGenerator.PropertyScore;
    }

    protected override void OnPickUp()
    {
        audioManager.PlayCoinSFX();
        score.ChangeScore(scoreToAdd);
    }
}
