using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed of movement
    public float maxYPosition = 5.0f; // Maximum height
    public GameObject userPrefab; // Add this line to create the public variable
    float timer = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60.0f;
        // Move the cube upwards along the y-axis
        if (seconds>=5.0f) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime * 1.2f);
        }

        // If the cube reaches the maximum height, reset its position
        if (transform.position.y >= maxYPosition)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
