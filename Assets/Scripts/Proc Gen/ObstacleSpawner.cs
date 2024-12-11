using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float posRange;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstaclesParent;
    [SerializeField] float obstacleTimeInterval;

    void Start()
    {
        StartCoroutine(ObstacleSpawnCoroutine());
    }

    IEnumerator ObstacleSpawnCoroutine()
    {
        while (true)
        {
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-posRange, posRange), 0, 0);
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstaclesParent);
            
            yield return new WaitForSeconds(obstacleTimeInterval);
        }
    }
}
