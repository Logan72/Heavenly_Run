using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] float posRange;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstaclesParent;
    [SerializeField] float obstacleTimeInterval;
    [SerializeField] float obstacleTimeIntervalScale;
    public static float maxObstacleDistance;

    void Start()
    {
        maxObstacleDistance = transform.position.z;
        StartCoroutine(ObstacleSpawnCoroutine());
    }

    IEnumerator ObstacleSpawnCoroutine()
    {
        while (true)
        {
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-posRange, posRange), 0, 0);
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            var newInstance = Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstaclesParent).GetComponent<Rock>();
            
            if(newInstance != null)
            {
                newInstance.Init(audioManager);
            }
            
            yield return new WaitForSeconds(obstacleTimeInterval);
        }
    }

    public void ModifyObstacleTimeInterval()
    {
        obstacleTimeInterval *= obstacleTimeIntervalScale;
    }
}
