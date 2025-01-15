using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    protected AudioManager audioManager;
    const string playerTag = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.attachedRigidbody.CompareTag(playerTag))
        //{
        OnPickUp();
        Destroy(gameObject);
        //}
    }

    public abstract void Init(LevelGenerator levelGenerator);

    protected abstract void OnPickUp();
}
