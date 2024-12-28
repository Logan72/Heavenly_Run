using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Header("Audio clips")]
    [SerializeField] AudioClip[] backgroundMusics;
    [SerializeField] AudioClip rockSFX;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip appleSFX;
    [SerializeField] AudioClip playerHurtSFX;
    [Header("Volumes")]
    [SerializeField] float rockSFX_maxVolume;
    [SerializeField] float rockSFX_minVolume;
    [SerializeField] float coinSFX_volumeScale;
    [SerializeField] float appleSFX_volumeScale;
    [SerializeField] float playerHurtSFX_volumeScale;

    public static AudioManager instance;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        KnuthShuffle(backgroundMusics);
        StartCoroutine(PlayBackgroundMusicsCoroutine());
    }

    IEnumerator PlayBackgroundMusicsCoroutine()
    {
        int i = 0;

        while (true)
        {
            audioSource.clip = backgroundMusics[i];
            audioSource.Play();
            if (++i == backgroundMusics.Length) i = 0;
                        
            yield return new WaitForSecondsRealtime(audioSource.clip.length);
        }
    }

    public void PlayPlayerHurtSFX()
    {
        audioSource.PlayOneShot(playerHurtSFX, playerHurtSFX_volumeScale);
    }

    public void PlayCoinSFX()
    {
        audioSource.PlayOneShot(coinSFX, coinSFX_volumeScale);
    }

    public void PlayAppleSFX()
    {
        audioSource.PlayOneShot(appleSFX, appleSFX_volumeScale);
    }

    public void PlayRockSFX(AudioSource rockAudioSource)
    {
        rockAudioSource.clip = rockSFX;
        rockAudioSource.volume = 10f / 
                                 Vector3.Distance(Camera.main.transform.position, rockAudioSource.transform.position) *
                                 rockSFX_maxVolume;
        rockAudioSource.volume = Mathf.Clamp(rockAudioSource.volume, rockSFX_minVolume, rockSFX_maxVolume);
        rockAudioSource.Play();
    }

    void KnuthShuffle<T>(T[] arr)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int i = 0; i < arr.Length; i++)
        {
            T tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
