using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Utility
{
    public static IEnumerator DoCoroutine(Action action, float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);

        action();
    }

    public static void KnuthShuffle<T>(T[] arr)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int i = 0; i < arr.Length; i++)
        {
            T tmp = arr[i];
            int r = UnityEngine.Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    public static void Play(AudioSource audioSource, AudioClip audioClip, float volume)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }

    public static void PlayRandom(AudioSource audioSource, AudioClip[] audioClips, float volume)
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.volume = volume;
        audioSource.Play();
    }

    public static void PlayOneShotRandom(AudioSource audioSource, AudioClip[] audioClips, float volumeScale)
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)], volumeScale);
    }
}
