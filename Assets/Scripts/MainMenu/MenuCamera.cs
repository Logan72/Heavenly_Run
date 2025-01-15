using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update()
    {
        Camera.main.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
