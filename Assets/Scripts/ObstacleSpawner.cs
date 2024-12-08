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
            Vector3 spawnPos = new Vector3(Random.Range(-posRange, posRange), transform.position.y, transform.position.z);
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstaclesParent);
            
            yield return new WaitForSeconds(obstacleTimeInterval);
        }
    }
}
