using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] int chunksNumber;
    [SerializeField] float chunkLength;
    [SerializeField] float chunkMoveSpeed;
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnChunks();
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
        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.Translate(-chunkMoveSpeed * Time.deltaTime * transform.forward);            
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
}
