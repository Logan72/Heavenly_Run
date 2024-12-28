using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Timer timer;
    [SerializeField] CameraController cameraController;
    [SerializeField] Distance distanceScore;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] Transform chunkParent;
    [Header("Other properties")]
    [SerializeField] int chunksBetweenCheckpoint;    
    [SerializeField] int activeChunksNumber;
    [SerializeField] float chunkLength;
    [SerializeField] float chunkMoveSpeed;
    [SerializeField] float minChunkMoveSpeed;
    [SerializeField] float maxChunkMoveSpeed;
    List<Chunk> chunks = new List<Chunk>();
    public static LevelGenerator lvlGen;
    [SerializeField] float minZGravity;
    [SerializeField] float maxZGravity;
    float chunkSpeedRange;
    int totalChunksNumber = 0;

    float speed_intrpolValue { get { return (chunkMoveSpeed - minChunkMoveSpeed) / chunkSpeedRange; } }

    void Start()
    {
        chunkSpeedRange = maxChunkMoveSpeed - minChunkMoveSpeed;
        SpawnChunks();
        lvlGen = this;
    }

    void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        Chunk newChunk = Instantiate(chunkPrefabs[0], transform.position, Quaternion.identity, chunkParent).GetComponent<Chunk>();
        newChunk.Init(timer);
        chunks.Add(newChunk);
        totalChunksNumber++;

        for (int i = 0; i < activeChunksNumber - 1; i++)
        {
            SpawnChunk();
        }
    }

    void MoveChunks()
    {
        float deltaDistance = chunkMoveSpeed * Time.deltaTime;

        distanceScore.distance += deltaDistance;

        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.Translate(-deltaDistance * transform.forward);            
        }

        if (chunks.Count != 0 && chunks[0].transform.position.z < Camera.main.transform.position.z - chunkLength)
        {
            Destroy(chunks[0].gameObject);
            chunks.RemoveAt(0);
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        GameObject chunkPrefabToSpawn = ChooseChunkToSpawn();

        Vector3 newChunkPosition = chunks[chunks.Count - 1].transform.position + new Vector3(0, 0, chunkLength);

        Chunk newChunk = Instantiate(chunkPrefabToSpawn, newChunkPosition, Quaternion.identity, chunkParent).GetComponent<Chunk>();
        newChunk.GetComponent<Checkpoint>()?.Init(timer);
        newChunk.Init(timer);
        chunks.Add(newChunk);
        totalChunksNumber++;
    }

    GameObject ChooseChunkToSpawn()
    {
        return totalChunksNumber % (chunksBetweenCheckpoint + 1) == 0 ?
                    chunkPrefabs[1] : chunkPrefabs[Random.Range(2, chunkPrefabs.Length)];
    }

    public void ChangeChunkMoveSpeed(float deltaSpeed)
    {
        chunkMoveSpeed += deltaSpeed;
        chunkMoveSpeed = Mathf.Clamp(chunkMoveSpeed, minChunkMoveSpeed, maxChunkMoveSpeed);

        float interpolationValue = speed_intrpolValue;

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Mathf.Lerp(maxZGravity, minZGravity, interpolationValue));

        cameraController.ModifyCameraFOV(interpolationValue);
    }
}
