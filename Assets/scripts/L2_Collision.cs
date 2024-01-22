using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public L2_GameOver gameover;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(647f, 31f, 597f);
            gameover.Setup(BlockSpawner.Instance.points);
            Debug.Log("Game Over! Player collided with this object.");
        }
    }
}
