using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Fence")]
    [SerializeField] GameObject fencePrefab;
    [SerializeField] int maxNumberOfFencesPerChunk;
    [Header("Apple")]
    [SerializeField] GameObject applePrefab;
    [SerializeField] float appleProbability;
    [Header("Coin")]
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float coinProbability;
    [Header("Position")]
    [SerializeField] float[] spawnPosX;
    [SerializeField] float[] spawnPosZ;
    List<int> availableLanes = new List<int>();
    List<int> availableRows = new List<int>();

    void Start()
    {
        for (int i = 0; i < spawnPosX.Length; i++)
        {
            availableLanes.Add(i);
        }

        for (int i = 0; i < spawnPosZ.Length; i++)
        {
            availableRows.Add(i);
        }

        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnCoins()
    {
        int lane = SelectRandomItem(availableLanes);

        for (int i = 0; i < availableRows.Count; i++)
        {
            if (Random.value > coinProbability) continue;

            Vector3 spawnPos = transform.position + new Vector3(spawnPosX[lane], 0, spawnPosZ[availableRows[i]]);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
        }        
    }

    void SpawnApple()
    {
        if (Random.value > appleProbability) return;

        Vector3 spawnPos = transform.position + new Vector3(spawnPosX[SelectRandomItem(availableLanes)], 0, spawnPosZ[TakeRandomItemOut(availableRows)]);
        Instantiate(applePrefab, spawnPos, Quaternion.identity, transform);
    }

    void SpawnFences()
    {
        int numberOfFences = Random.Range(0, maxNumberOfFencesPerChunk + 1);

        for (int i = 0; i < numberOfFences; i++)
        {                       
            Vector3 spawnPos = transform.position + new Vector3(spawnPosX[TakeRandomItemOut(availableLanes)], 0, 0);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, transform);
        }
    }

    int TakeRandomItemOut(List<int> list)
    {        
        int selectedItem = SelectRandomItem(list);
        list.Remove(selectedItem);
        return selectedItem;
    }

    int SelectRandomItem(List<int> list)
    {
        int randomIndex = Random.Range(0, list.Count);        
        return list[randomIndex];
    }
}
