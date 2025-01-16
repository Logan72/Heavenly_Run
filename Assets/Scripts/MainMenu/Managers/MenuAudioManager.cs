using UnityEngine;
using UnityEngine.Audio;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Header("Audio clips")]
    [SerializeField] AudioClip buttonSFX;
    [SerializeField] AudioClip specialButtonSFX;
    [Header("Volumes")]
    [SerializeField] float buttonSFX_volumeScale;
    [SerializeField] float specialButtonSFX_volumeScale;

    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(buttonSFX, buttonSFX_volumeScale);
    }

    public void PlaySpecialButtonSFX()
    {
        audioSource.PlayOneShot(specialButtonSFX, specialButtonSFX_volumeScale);
    }
}
