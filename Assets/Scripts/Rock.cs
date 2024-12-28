using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem wreckageVFX;
    [SerializeField] float bounceScale;
    [SerializeField] float collisionFX_threshhold;
    [SerializeField] float maxShakeForce;
    Rigidbody rb;
    CinemachineImpulseSource cinemachineImpulseSource;
    const string fenceTag = "Fence";
    const string roadTag = "Road";

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case fenceTag:
                PartiallyProcessCollision(collision);
                rb.AddForce(0f, rb.mass * bounceScale, 0f);
                break;
            case roadTag:
                if (rb.linearVelocity.y > collisionFX_threshhold) PartiallyProcessCollision(collision);
                break;               
        }
    }

    void PartiallyProcessCollision(Collision collision)
    {
        PlayWreckageVFX(collision);
        ShakeCamera();
        AudioManager.instance.PlayRockSFX(audioSource);
    }

    void ShakeCamera()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeForce = 10f / distance;
        shakeForce = Mathf.Min(shakeForce, maxShakeForce);
        cinemachineImpulseSource.GenerateImpulse(shakeForce);
    }

    void PlayWreckageVFX(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);
        wreckageVFX.transform.position = contactPoint.point;
        wreckageVFX.Play();
    }
}
