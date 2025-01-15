using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        try
        {
            Destroy(other.attachedRigidbody.gameObject);
        }
        catch { }
    }
}
