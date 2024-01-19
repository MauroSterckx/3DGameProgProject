using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    public List<GameObject> waypoints;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        MoveCamera();
        MoveCharacter();
    }

    private void MoveCamera()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }

    private void MoveCharacter()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        transform.position += (moveSpeed * moveHorizontal) * Time.deltaTime * Vector3.back;

        Debug.Log("Horizontal Input: " + moveHorizontal);
        Debug.Log("Character Position: " + transform.position);
    }

    private void OnHorizontal(InputValue value)
    {
        float horizontal = value.Get<float>();

        // Check if there's a collision before allowing movement
        if (!IsColliding())
        {
            transform.position += (moveSpeed * horizontal) * Time.deltaTime * Vector3.forward;
        }

        Debug.Log("Horizontal Input: " + horizontal);
        Debug.Log("Character Position: " + transform.position);
    }

    private bool IsColliding()
    {
        // Perform a simple check for collisions here
        // You might want to use a more sophisticated approach based on your game's needs

        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                return true;
            }
        }

        return false;
    }

}
