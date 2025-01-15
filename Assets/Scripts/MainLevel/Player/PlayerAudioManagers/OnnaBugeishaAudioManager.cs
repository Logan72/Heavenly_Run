using UnityEngine;

public class OnnaBugeishaAudioManager : MonoBehaviour
{
    [Header("Audio clips")]
    [SerializeField] AudioClip[] hurtSFXs;
    [SerializeField] AudioClip dyingSFX;
    [SerializeField] AudioClip specialSFX;
    [Header("Volumes")]
    [SerializeField] float hurtSFXs_volume;
    [SerializeField] float dyingSFX_volume;
    [SerializeField] float specialSFX_volume;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHurtSFX()
    {
        Utility.PlayRandom(audioSource, hurtSFXs, hurtSFXs_volume);
    }

    public void PlayDyingSFX()
    {
        Utility.Play(audioSource, dyingSFX, dyingSFX_volume);
    }

    public void PlaySpecialSFX()
    {
        Utility.Play(audioSource, specialSFX, specialSFX_volume);
    }
}
