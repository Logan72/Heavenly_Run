using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float deltaSpeed;

    protected override void OnPickUp()
    {
        LevelGenerator.lvlGen.ChangeChunkMoveSpeed(deltaSpeed);
    }
}
