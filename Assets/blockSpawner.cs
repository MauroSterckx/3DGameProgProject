using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpawner : MonoBehaviour { 

    public GameObject blockPrefab; // The prefab of the block you want to generate
    public Transform targetObject; // The object that jumps on the generated blocks
    public float maxDistance = 10.0f; // Maximum distance for block generation

    public int numberOfBlocks = 5; // Number of blocks to generate initially

    bool shouldGenerateBlocks = false;

    void Start()
    {
        GenerateBlocks(); // Spawn initial blocks when the game starts
    }

    void Update()
    {
        if (shouldGenerateBlocks)
        {
            GenerateBlocks();
            shouldGenerateBlocks = false; // Reset the flag after generating blocks
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject.gameObject)
        {
            shouldGenerateBlocks = true; // Activate block generation when targetObject jumps on a block
        }
    }

    void GenerateBlocks()
    {
        if (blockPrefab == null || targetObject == null)
        {
            Debug.LogError("Block prefab or target object not assigned!");
            return;
        }

        for (int i = 0; i < numberOfBlocks; i++)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-maxDistance, maxDistance), 0f, Random.Range(-maxDistance, maxDistance));
            Vector3 spawnPosition = targetObject.position + randomOffset;

            GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
            // You can also set specific properties or behaviors for the generated blocks here if needed
        }
    }
}
