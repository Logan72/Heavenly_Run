using System;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] TMP_Text signTMP;
    ObstacleSpawner obstacleSpawner;
    AudioManager audioManager;
    static int numberOfCheckpoints;
    const string playerTag = "Player";

    public void Init(LevelGenerator levelGenerator)
    {
        obstacleSpawner = levelGenerator.PropertyObstacleSpawner;
        audioManager = levelGenerator.PropertyAudioManager;
    }

    void Start()
    {
        signTMP.text = (++numberOfCheckpoints).ToString();
        Chunk.ModifyChunkParameters();
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.attachedRigidbody.CompareTag(playerTag))
        //{
        obstacleSpawner.ModifyObstacleTimeInterval();
        audioManager.PlayCheckpointSFX();
        //}
    }

    public static void ResetNumberOfCheckpoints() => numberOfCheckpoints = 0;
}
