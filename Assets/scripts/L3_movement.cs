using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_movement : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 5f;

    public float stopZPosition = 0f; // Z-positie waarop de beweging moet stoppen
    public float maxZPosition = 5f; // Maximale Z-positie waarop de beweging moet stoppen

    private char dest = 'X';

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = new Vector3(-speed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
        if (Input.GetKey(KeyCode.Space))
        {
            //jump
        }
        if (Input.GetKey("q")) //pas aan naar a
        {
            body.velocity = new Vector3(-speed,0,5);
            StartCoroutine(StopLaner());   
            
            
        }
        if (Input.GetKey("d"))
        {
            body.velocity = new Vector3(-speed, 0, -5);
            StartCoroutine(StopLaner());
        }
        
    }


    void MoveCam()
    {
        Camera.main.transform.Translate(new Vector3(0f, 0f, speed * Time.deltaTime));
    }

    IEnumerator StopLaner()
    {
        yield return new WaitForSeconds(1);
        body.velocity = new Vector3(-speed, 0, 0);
    }
    
}
