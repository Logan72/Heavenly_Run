using UnityEngine;
using UnityEngine.InputSystem;

public class JumperController : PlayerController
{
    [SerializeField] Transform jumpingCubeTransform;
    [SerializeField] float jumpScale;

    protected override void FixedUpdate()
    {
        ProcessMovement(jumpingCubeTransform.localPosition.y);
    }

    protected override void DoSpecial()
    {
        animator.SetTrigger(specialParameter);
        Jump();
    }

    void Jump()
    {
        Rigidbody cubeRigidbody = jumpingCubeTransform.GetComponent<Rigidbody>();
        cubeRigidbody.AddForce(0f, cubeRigidbody.mass * jumpScale, 0f);
    }
}
