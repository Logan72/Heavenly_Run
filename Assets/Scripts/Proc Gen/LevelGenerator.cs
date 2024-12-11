using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Distance distanceScore;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] int chunksNumber;
    [SerializeField] float chunkLength;
    [SerializeField] float chunkMoveSpeed;
    [SerializeField] float minChunkMoveSpeed;
    [SerializeField] float maxChunkMoveSpeed;
    List<GameObject> chunks = new List<GameObject>();
    public static LevelGenerator lvlGen;
    [SerializeField] float minZGravity;
    [SerializeField] float maxZGravity;

    void Start()
    {
        SpawnChunks();
        lvlGen = this;
    }

    void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        chunks.Add(Instantiate(chunkPrefab, transform.position, Quaternion.identity, chunkParent));

        for (int i = 0; i < chunksNumber - 1; i++)
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
            Destroy(chunks[0]);
            chunks.RemoveAt(0);
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        Vector3 newChunkPosition = chunks[chunks.Count - 1].transform.position + new Vector3(0, 0, chunkLength);
        GameObject newChunk = Instantiate(chunkPrefab, newChunkPosition, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    public void ChangeChunkMoveSpeed(float deltaSpeed)
    {
        chunkMoveSpeed += deltaSpeed;
        chunkMoveSpeed = Mathf.Clamp(chunkMoveSpeed, minChunkMoveSpeed, maxChunkMoveSpeed);

        Physics.gravity = Physics.gravity - new Vector3(0f, 0f, deltaSpeed);
        float zGravity = Mathf.Clamp(Physics.gravity.z, minZGravity, maxZGravity);
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, zGravity);
    }
}
