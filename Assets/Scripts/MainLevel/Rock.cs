using Unity.Cinemachine;
using UnityEngine;

public class Rock : HealthEater
{
    [SerializeField] ParticleSystem wreckageVFX;
    [SerializeField] float bounceScale;
    [SerializeField] float collisionFX_threshhold;
    [SerializeField] float maxShakeForce;
    [SerializeField] float minShakeForce;
    AudioSource audioSource;
    Rigidbody rb;
    CinemachineImpulseSource cinemachineImpulseSource;
    AudioManager audioManager;
    const string fenceTag = "Fence";
    const string roadTag = "Road";
    float InterpolationValue
    {
        get
        {
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            return distance / ObstacleSpawner.maxObstacleDistance;
        }
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Init(AudioManager audioManager)
    {
        this.audioManager = audioManager;
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
        float interpolationValue = InterpolationValue;

        PlayWreckageVFX(collision);
        ShakeCamera(interpolationValue);
        audioManager.PlayRockSFX(audioSource, interpolationValue);
    }    

    void ShakeCamera(float interpolationValue)
    {        
        float shakeForce = Mathf.Lerp(maxShakeForce, minShakeForce, interpolationValue);
        cinemachineImpulseSource.GenerateImpulse(shakeForce);
    }

    void PlayWreckageVFX(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);
        wreckageVFX.transform.position = contactPoint.point;
        wreckageVFX.Play();
    }
}
