using System;
using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    CollectedPotions collectedPotions;
    Health health;
    [SerializeField] int maxHealth;
    [SerializeField] float damageScale;
    [SerializeField] protected Animator animator;
    [SerializeField] float stumbleSFXcoolDownTime;
    float stumbleSFXcoolDownTimer = 0f;
    Collision collision;
    Rigidbody latestObstacleRigidbody;
    const float waist = 1.15f;
    const string stumbleTrigger = "Stumble";
    const string fallBackTrigger = "FallBack";
    const string tripTrigger = "Trip";
    const string flyBackTrigger = "FlyBack";    

    public void Init(CollectedPotions collectedPotions, Health health)
    {
        health.Init(maxHealth, this);
        this.collectedPotions = collectedPotions;
        this.health = health;
    }

    void Update()
    {
        stumbleSFXcoolDownTimer += Time.deltaTime;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        NewMethod1(collision, NewMethod2);
    }

    protected void NewMethod1(Collision collision, Action<Collision> action)
    {
        if (latestObstacleRigidbody != collision.rigidbody)
        {
            latestObstacleRigidbody = collision.rigidbody;
            action(collision);
        }
    }

    void NewMethod2(Collision collision)
    {
        this.collision = collision;
        health.ChangeHealth(TryReduceDamage());
    }

    int TryReduceDamage()
    {
        //apply armour
        float deltaHealth1 = latestObstacleRigidbody.GetComponent<HealthEater>().DeltaHealth * damageScale;
        //apply potion
        int deltaHealth2 = collectedPotions.ModifyDeltaHealth(deltaHealth1);
        return deltaHealth2;
    }

    public void Stumble()
    {
        if (stumbleSFXcoolDownTimer > stumbleSFXcoolDownTime)
        {
            stumbleSFXcoolDownTimer = 0f;
            PlayHurtSFX();
        }

        animator.SetTrigger(stumbleTrigger);
    }

    public void Die()
    {
        PlayDyingSFX();       

        if (latestObstacleRigidbody.GetComponent<Rock>() != null)
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

    protected virtual void PlayHurtSFX() { }
    protected virtual void PlayDyingSFX() { }
}
