using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] CollectedPotions collectedPotions;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Health health;
    [SerializeField] Animator animator;
    [SerializeField] float coolDownTime;
    AudioSource audioSource;
    float coolDownTimer = 0f;
    Collision collision;
    Rigidbody latestObstacleRigidbody;
    const float waist = 1.15f;
    const string stumbleTrigger = "Stumble";
    const string fallBackTrigger = "FallBack";
    const string tripTrigger = "Trip";
    const string flyBackTrigger = "FlyBack";

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //void Start()
    //{
    //    StartCoroutine(DoCoroutine());
    //}

    void Update()
    {
        coolDownTimer += Time.deltaTime;
    }

    //IEnumerator DoCoroutine()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Stumble();
    //    yield return new WaitForSeconds(0.2f);
    //    Die();
    //}

    void OnCollisionEnter(Collision collision)
    {
        if ((coolDownTimer > coolDownTime) && (latestObstacleRigidbody != collision.rigidbody))
        {
            coolDownTimer = 0f;
            this.collision = collision;
            latestObstacleRigidbody = collision.rigidbody;
            int finalDeltaHealth = collectedPotions.ModifyDeltaHealth(collision.rigidbody.GetComponent<HealthEater>().DeltaHealth);
            health.ChangeHealth(finalDeltaHealth);
        }
    }

    public void Stumble()
    {
        audioManager.PlayPlayerHurtSFX(audioSource);
        animator.SetTrigger(stumbleTrigger);
    }

    public void Die()
    {
        audioManager.PlayPlayerDyingSFX(audioSource);        

        if (collision.rigidbody.GetComponent<Rock>() != null)
        {
            animator.SetTrigger(flyBackTrigger);
        }
        else
        {
            Vector3 localPoint = animator.transform.InverseTransformPoint(collision.GetContact(0).point);

            if (localPoint.y < waist)
            {
                animator.SetTrigger(tripTrigger);
            }
            else
            {
                animator.SetTrigger(fallBackTrigger);
            }
        }

        Destroy(this);
    }
}
