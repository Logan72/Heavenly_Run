using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    protected AudioManager audioManager;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        OnPickUp();
        Destroy(gameObject);
    }

    public abstract void Init(LevelGenerator levelGenerator);

    protected abstract void OnPickUp();
}
