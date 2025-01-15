using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Fence")]
    [SerializeField] Transform fenceParent;
    [SerializeField] GameObject fencePrefab;
    [SerializeField] int maxNumberOfFencesPerChunk;
    [Header("Apple")]
    [SerializeField] GameObject applePrefab;        
    [SerializeField] float appleProbability;
    [Header("Potion")]
    [SerializeField] GameObject potionPrefab;
    [SerializeField] float potionProbability;
    [Header("GoldCoin")]
    [SerializeField] GameObject goldCoinPrefab;
    [SerializeField] float goldCoinProbability;
    [Header("CopperCoin")]
    [SerializeField] GameObject copperCoinPrefab;
    [SerializeField] float copperCoinProbability;
    [Header("Position")]
    [SerializeField] float[] spawnPosX;
    [SerializeField] float[] spawnPosZ;
    List<int> availableLanes = new List<int>();
    List<int> availableRows = new List<int>();
    LevelGenerator levelGenerator;
    static float appleProbabilityScale;

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
        SpawnPotion();
        SpawnGoldCoin();
        SpawnCopperCoins();
    }

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    void SpawnCopperCoins()
    {
        int lane = SelectRandomItem(availableLanes);

        for (int i = 0; i < availableRows.Count; i++)
        {
            if (Random.value > copperCoinProbability) continue;

            Vector3 spawnPos = transform.position + new Vector3(spawnPosX[lane], 0, spawnPosZ[availableRows[i]]);
            var newInstance = Instantiate(copperCoinPrefab, spawnPos, Quaternion.identity, transform);
            newInstance.GetComponent<Pickup>().Init(levelGenerator);
        }        
    }

    void SpawnApple()
    {
        appleProbability *= appleProbabilityScale;
        SpawnRareItem(applePrefab, appleProbability);
    }

    void SpawnPotion()
    {
        SpawnRareItem(potionPrefab, potionProbability);
    }

    void SpawnGoldCoin()
    {
        SpawnRareItem(goldCoinPrefab, goldCoinProbability);
    }

    void SpawnRareItem(GameObject prefab, float probability)
    {
        if (Random.value > probability) return;

        Vector3 spawnPos = transform.position + new Vector3(spawnPosX[SelectRandomItem(availableLanes)], 0, spawnPosZ[TakeRandomItemOut(availableRows)]);
        var newInstance = Instantiate(prefab, spawnPos, Quaternion.identity, transform);
        newInstance.GetComponent<Pickup>().Init(levelGenerator);
    }

    void SpawnFences()
    {
        int numberOfFences = Random.Range(0, maxNumberOfFencesPerChunk + 1);
        
        for (int i = 0; i < numberOfFences; i++)
        {                       
            Vector3 spawnPos = transform.position + new Vector3(spawnPosX[TakeRandomItemOut(availableLanes)], 0, 0);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, fenceParent);
        }
    }

    public static void ModifyChunkParameters()
    {
        ModifyAppleProbabilityScale();
    }

    static void ModifyAppleProbabilityScale() => appleProbabilityScale *= 0.95f;

    public static void ResetStaticMembers()
    {
        appleProbabilityScale = 1f;
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
