using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] spawnPosX;
    [SerializeField] int maxNumberOfFencesPerChunk;
    [SerializeField] GameObject applePrefab;
    List<int> availableLanes = new List<int>();

    void Start()
    {
        for (int i = 0; i < spawnPosX.Length; i++)
        {
            availableLanes.Add(i);
        }

        SpawnFence();
        SpawnApple();
    }

    void SpawnApple()
    {
        
    }

    void SpawnFence()
    {
        int numberOfFences = Random.Range(0, maxNumberOfFencesPerChunk + 1);

        for (int i = 0; i < numberOfFences; i++)
        {
            int selectedLane = SelectLane();
            Vector3 spawnPos = new Vector3(spawnPosX[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, transform);
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
