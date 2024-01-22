using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Reference to the block prefab
    public Transform targetObject; // Reference to the target cube
    public float maxDistance = 5.0f; // Maximum distance for block generation

    bool shouldGenerateBlock = true;

    void Start()
    {
        SpawnBlock(); // Spawn the initial block when the game starts
    }

    void Update()
    {
        // No need for continuous checks in Update
        // Use OnCollisionEnter events instead
    }

    // Called when a Collider enters the collision zone
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        if (shouldGenerateBlock && collision.gameObject.CompareTag("Player"))
        {
            SpawnBlock();
            shouldGenerateBlock = false;
        }
    }


    void SpawnBlock()
    {
        if (blockPrefab == null || targetObject == null)
        {
            Debug.LogError("Block prefab or target object not assigned!");
            return;
        }

        Vector3 randomOffset = new Vector3(Random.Range(-maxDistance, maxDistance), 0f, Random.Range(-maxDistance, maxDistance));
        Vector3 spawnPosition = targetObject.position + randomOffset;

        GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }
}
