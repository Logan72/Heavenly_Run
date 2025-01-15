using UnityEngine;

public class KnightAudioManager : MonoBehaviour
{
    [Header("Audio clips")]
    [SerializeField] AudioClip hurtSFX;
    [SerializeField] AudioClip dyingSFX;
    [SerializeField] AudioClip specialSFX;
    [SerializeField] AudioClip[] blockingSFXs;
    [Header("Volumes")]
    [SerializeField] float hurtSFX_volume;
    [SerializeField] float dyingSFX_volume;
    [SerializeField] float specialSFX_volume;
    [SerializeField] float blockingSFXs_volume;
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

    public void PlaySpecialSFX()
    {
        Utility.Play(audioSource, specialSFX, specialSFX_volume);
    }

    public void PlayBlockingSFX()
    {
        Utility.PlayOneShotRandom(audioSource, blockingSFXs, blockingSFXs_volume);
    }
}
