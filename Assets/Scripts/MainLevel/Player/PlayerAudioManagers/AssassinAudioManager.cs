using UnityEngine;

public class AssassinAudioManager : MonoBehaviour
{
    [Header("Audio clips")]
    [SerializeField] AudioClip hurtSFX;
    [SerializeField] AudioClip dyingSFX;
    [Header("Volumes")]
    [SerializeField] float hurtSFX_volume;
    [SerializeField] float dyingSFX_volume;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHurtSFX()
    {
        Utility.Play(audioSource, hurtSFX, hurtSFX_volume);
    }

    public void PlayDyingSFX()
    {
        Utility.Play(audioSource, dyingSFX, dyingSFX_volume);
    }
}
