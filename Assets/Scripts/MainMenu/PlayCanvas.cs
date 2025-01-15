using UnityEngine;

public class PlayCanvas : MonoBehaviour
{
    [SerializeField] GameObject characterContainer;

    void OnEnable()
    {
        characterContainer.SetActive(true);
    }

    void OnDisable()
    {
        characterContainer.SetActive(false);
    }
}
