using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CollectedPotions potionsManager;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Health health;
    [SerializeField] Score score;
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] Transform chunkParent;
    [Header("Other properties")]
    [SerializeField] int chunksBetweenCheckpoints;    
    [SerializeField] int activeChunksNumber;
    [SerializeField] float chunkLength;
    [SerializeField] float chunkMoveSpeed;
    [SerializeField] float minChunkMoveSpeed;
    [SerializeField] float maxChunkMoveSpeed;
    [SerializeField] float minZGravity;
    [SerializeField] float maxZGravity;
    List<Chunk> chunks = new List<Chunk>();
    int totalChunksNumber = 0;
    public AudioManager PropertyAudioManager { get { return audioManager; } }
    public Health PropertyHealth { get { return health; } }
    public Score PropertyScore { get { return score; } }
    public CollectedPotions PotionsManager { get {return potionsManager; } }
    public ObstacleSpawner PropertyObstacleSpawner { get { return obstacleSpawner; } }

    void Start()
    {
        Chunk.ResetStaticMembers();
        Checkpoint.ResetNumberOfCheckpoints();
        SpawnChunks();
        enabled = false;
    }

    void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        Chunk newChunk = Instantiate(chunkPrefabs[0], transform.position, Quaternion.identity, chunkParent).GetComponent<Chunk>();
        newChunk.Init(this);
        chunks.Add(newChunk);
        totalChunksNumber++;

        SpawnChunk(chunkPrefabs[0]);

        for (int i = 0; i < activeChunksNumber - 1; i++)
        {
            SpawnChunk(ChooseChunkToSpawn());
        }
    }

    void MoveChunks()
    {
        float deltaDistance = chunkMoveSpeed * Time.deltaTime;

        score.ChangeScore(deltaDistance);

        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.Translate(-deltaDistance * transform.forward);            
        }

        if (chunks.Count != 0 && chunks[0].transform.position.z < Camera.main.transform.position.z - chunkLength)
        {
            Destroy(chunks[0].gameObject);
            chunks.RemoveAt(0);
            SpawnChunk(ChooseChunkToSpawn());
        }
    }

    void SpawnChunk(GameObject chunkPrefabToSpawn)
    {
        Vector3 newChunkPosition = chunks[chunks.Count - 1].transform.position + new Vector3(0, 0, chunkLength);

        Chunk newChunk = Instantiate(chunkPrefabToSpawn, newChunkPosition, Quaternion.identity, chunkParent).GetComponent<Chunk>();
        newChunk.Init(this);
        chunks.Add(newChunk);

        Checkpoint newCheckpoint = newChunk.GetComponent<Checkpoint>();
        if (newCheckpoint != null) newCheckpoint.Init(this);
        
        totalChunksNumber++;
    }

    GameObject ChooseChunkToSpawn()
    {
        return totalChunksNumber % (chunksBetweenCheckpoints + 1) == 0 ?
                    chunkPrefabs[1] : chunkPrefabs[Random.Range(2, chunkPrefabs.Length)];
    }

    public void ChangeChunkMoveSpeed(float interpolationValue)
    {
        chunkMoveSpeed = Mathf.Lerp(minChunkMoveSpeed, maxChunkMoveSpeed, interpolationValue);
        
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Mathf.Lerp(maxZGravity, minZGravity, interpolationValue));

        cameraController.ModifyCameraFOV(interpolationValue);
    }
}
