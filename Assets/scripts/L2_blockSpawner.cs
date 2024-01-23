using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner Instance;
    public GameObject blockPrefab; // Reference to the block prefab
    public GameObject collisionParticles;
    public L2_Finish finish;
    public int points = 0;
    private Rigidbody rb;
    private int countBlocks = 1;
    private float temp;
    bool shouldGenerateBlock = true;

    void Start()
    {
    }

    void Update()
    {
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (countBlocks == 11)
        {
            finish.Setup(points);
        }
        else if (collision.gameObject.CompareTag("Block") && countBlocks <= 10 && transform.position.y>=temp)
        {
            if (collisionParticles != null)
            {
                GameObject particles = Instantiate(collisionParticles, collision.transform.position, Quaternion.identity);
                Destroy(particles, 3f);
            }
            for (int i=0;i<1;i++) {
                points += 1;
                SpawnBlock();
            }
        }
    }


    void SpawnBlock()
    {
        countBlocks = countBlocks + 1;
        if (blockPrefab == null)
        {
            Debug.LogError("Block prefab or target object not assigned!");
            return;
        }

        if (shouldGenerateBlock == true) {
            float horizontalOffsetLower = Random.Range(-70, -40);
            float horizontalOffsetHigher = Random.Range(40, 70);
            int rndValue = Random.Range(0, 2);
            if (rndValue==1) {
                Vector3 spawnPosition = new Vector3(transform.position.x + horizontalOffsetLower, transform.position.y + 25.0f, transform.position.z + horizontalOffsetLower);
                GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
                temp = newBlock.transform.position.y;
            }
            else
            {
                Vector3 spawnPosition = new Vector3(transform.position.x + horizontalOffsetHigher, transform.position.y + 25.0f, transform.position.z + horizontalOffsetHigher);
                GameObject newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
                temp = newBlock.transform.position.y;
            }

        }
    }
}
