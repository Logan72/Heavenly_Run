using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedUpVFX;
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] float maxFOV;
    [SerializeField] float minFOV;
    [SerializeField] float zoomDuration;
    [SerializeField] float zoomMultiplier;

    public void ModifyCameraFOV(float interpolationValue)
    {
        StopAllCoroutines();
        StartCoroutine(ModifyCameraFOVCoroutine(interpolationValue));
    }

    IEnumerator ModifyCameraFOVCoroutine(float interpolationValue)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, interpolationValue);
        float elapsedTime = 0f;

        if(startFOV < targetFOV) speedUpVFX.Play();

        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / zoomDuration;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);

            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
