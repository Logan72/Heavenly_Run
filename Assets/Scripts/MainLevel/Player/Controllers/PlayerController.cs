using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] float minMovementSpeed;
    [SerializeField] float maxMovementSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] float rangeX;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    [SerializeField] float specialCoolDownTime;
    SpecialSkill specialSkill;
    Rigidbody rb;
    Vector2 movementDirectionV2;
    public const string specialParameter = "Special";
    bool isGameOver = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }

    public void Init(SpecialSkill specialSkill)
    {
        this.specialSkill = specialSkill;
        specialSkill.Init(specialCoolDownTime);
    }

    protected virtual void FixedUpdate()
    {
        ProcessMovement(transform.position.y);
    }

    protected void ProcessMovement(float y)
    {
        Vector3 movementDirectionV3 = new Vector3(movementDirectionV2.x, 0f, movementDirectionV2.y);
        Vector3 movement = movementSpeed * Time.fixedDeltaTime * movementDirectionV3;
        Vector3 destination = new Vector3(rb.position.x, y, rb.position.z) + movement;

        destination.x = Mathf.Clamp(destination.x, -rangeX, rangeX);
        destination.z = Mathf.Clamp(destination.z, minZ, maxZ);
        
        rb.MovePosition(destination);
    }

    void OnMove(InputValue inputValue)
    {
        if (!isGameOver)
        {
            movementDirectionV2 = inputValue.Get<Vector2>();
        }
        else movementDirectionV2 = Vector2.zero;
    }

    public void ChangePlayerSpeed(float interpolationValue)
    {
        movementSpeed = Mathf.Lerp(minMovementSpeed, maxMovementSpeed, interpolationValue);
    }

    void OnDoSpecial()
    {
        if (!isGameOver && specialSkill.isCooledDown)
        {
            DoSpecial();

            specialSkill.Reset();
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
    }

    protected virtual void DoSpecial() { }
}
