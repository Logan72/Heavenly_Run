using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] float addedTime;
    Timer timer;

    public void Init(Timer timer)
    {
        this.timer = timer;
    }

    protected override void OnPickUp()
    {
        AudioManager.instance.PlayCoinSFX();
        timer.ModifyTime(addedTime);
    }
}
