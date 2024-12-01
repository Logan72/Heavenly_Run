using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] int chunksNumber;
    [SerializeField] float chunkLength;

    void Start()
    {
        for (int i = 0; i < chunksNumber; i++)
        {
            Vector3 chunkPosition = transform.position + new Vector3(0, 0, chunkLength * i);
            Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunkParent);
        }
    }
}
