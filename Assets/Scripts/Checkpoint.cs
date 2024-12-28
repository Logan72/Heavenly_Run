using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeToAdd;
    Timer timer;
    const string playerTag = "Player";

    public void Init(Timer timer)
    {
        this.timer = timer;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) timer.ModifyTime(timeToAdd);
    }
}
