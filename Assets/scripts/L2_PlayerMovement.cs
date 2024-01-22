using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float jumpForce = 5.0f;
    public float maxRotationAngle = 30.0f;

    private Rigidbody rb;
    public bool isGrounded = true;
    private bool hasPressedSpace = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasPressedSpace = false;
        }
    }


    void Update()
    {
        Move();
        RotateCamera();
        // Check for jump only when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !hasPressedSpace)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveZ, 0.0f, moveX);
        movement = transform.TransformDirection(movement) * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    void RotateCamera()
    {
        float rotateAmount = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        Quaternion newRotation = Quaternion.Euler(0.0f, rotateAmount, 0.0f) * rb.rotation;

        float angle = Quaternion.Angle(rb.rotation, newRotation);
        if (angle <= maxRotationAngle)
        {
            rb.MoveRotation(newRotation);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics.gravity.y)), ForceMode.Impulse);
        isGrounded = false;
    }
}
