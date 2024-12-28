using UnityEngine;

public class Apple : Pickup
{
    [Tooltip("The value to add to chunks' speed.")]
    [SerializeField] float deltaSpeed;

    protected override void OnPickUp()
    {
        AudioManager.instance.PlayAppleSFX();
        LevelGenerator.lvlGen.ChangeChunkMoveSpeed(deltaSpeed);
    }
}
