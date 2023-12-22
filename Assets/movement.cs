using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float jumpForce = 5.0f;
    public bool isGrounded;
    public float maxRotationAngle = 30.0f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        Move();
        RotateCamera();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement in the horizontal and vertical axes
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
        movement = transform.TransformDirection(movement) * moveSpeed * Time.deltaTime;

        // Apply the movement to the rigidbody
        rb.MovePosition(rb.position + movement);
    }

    void RotateCamera()
    {
        float rotateAmount = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Calculate the new rotation based on current rotation and mouse input
        Quaternion newRotation = Quaternion.Euler(0.0f, rotateAmount, 0.0f) * rb.rotation;

        // Limit rotation angle to a maximum value
        float angle = Quaternion.Angle(rb.rotation, newRotation);
        if (angle <= maxRotationAngle)
        {
            rb.MoveRotation(newRotation);
        }
    }

    void Jump()
    {
        isGrounded = false;

        // Calculate jump velocity based on desired force and gravity
        float jumpVelocity = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics.gravity.y));

        // Set the rigidbody's velocity only on the Y-axis for a consistent jump
        Vector3 newVelocity = rb.velocity;
        newVelocity.y = jumpVelocity;
        rb.velocity = newVelocity;
    }
}
