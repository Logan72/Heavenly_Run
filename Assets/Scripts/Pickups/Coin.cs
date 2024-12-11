using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] float addedTime;

    protected override void OnPickUp()
    {
        Timer._timer.timeLeft += addedTime;
    }
}
