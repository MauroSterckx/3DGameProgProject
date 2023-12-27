using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed of movement
    public float maxYPosition = 5.0f; // Maximum height

    private void Update()
    {
        // Move the cube upwards along the y-axis
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // If the cube reaches the maximum height, reset its position
        if (transform.position.y >= maxYPosition)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
