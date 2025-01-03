using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float minMovementSpeed;
    [SerializeField] float maxMovementSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] float rangeX;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    Rigidbody rb;
    Vector2 movementDirectionV2;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        Vector3 movementDirectionV3 = new Vector3(movementDirectionV2.x, 0f, movementDirectionV2.y);
        Vector3 destination = rb.position + movementSpeed * Time.fixedDeltaTime * movementDirectionV3;

        destination.x = Mathf.Clamp(destination.x, -rangeX, rangeX);
        destination.z = Mathf.Clamp(destination.z, minZ, maxZ);

        rb.MovePosition(destination);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementDirectionV2 = context.ReadValue<Vector2>();
    }

    public void ChangePlayerSpeed(float interpolationValue)
    {
        movementSpeed = Mathf.Lerp(minMovementSpeed, maxMovementSpeed, interpolationValue);
    }
}
