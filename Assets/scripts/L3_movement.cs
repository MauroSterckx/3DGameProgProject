using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_movement : MonoBehaviour
{
    public Rigidbody body;
    public Rigidbody enemy;
    public float speed = 5f;

    public float stopZPosition = 0f; // Z-positie waarop de beweging moet stoppen
    public float maxZPosition = 5f; // Maximale Z-positie waarop de beweging moet stoppen

    private bool inchange = false;
    public float CamLockedPos = 2.880166f;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = new Vector3(-speed,0,0);
        enemy.velocity = new Vector3(-speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
        if (Input.GetKey(KeyCode.Space) && inchange == false)
        {
            //jump
        }
        if (Input.GetKey("q") && inchange == false) //pas aan naar a
        {
            inchange = true;
            body.velocity = new Vector3(-speed,0,-5);
            StartCoroutine(StopLaner());
            

        }
        if (Input.GetKey("d") && inchange == false)
        {
            inchange = true;
            body.velocity = new Vector3(-speed, 0, 5);
            StartCoroutine(StopLaner());
            
        }
        
    }

    // Wordt aangeroepen wanneer het object in aanraking komt met een ander collider
    void OnCollisionEnter(Collision collision)
    {
        // Controleer of het object waarmee het personage botst de tag "fish" heeft
        if (collision.gameObject.CompareTag("fish"))
        {
            // Voer hier de acties uit die moeten plaatsvinden als het personage een "fish" raakt (bijvoorbeeld doodgaan)
            // Voeg hier je eigen doodgaan-implementatie toe
            HandleDeath();
        }
    }

    // Voeg je eigen doodgaan-implementatie toe
    void HandleDeath()
    {
        // Implementeer hier wat er moet gebeuren wanneer het personage "dood" gaat
        Debug.Log("Het personage is dood gegaan!");
    }

    void MoveCam()
    {

        Vector3 newPosition = Camera.main.transform.position;
        newPosition.y = CamLockedPos; // Stel de Y-positie in op de vergrendelde waarde
        Camera.main.transform.position = newPosition;
        //
        Camera.main.transform.Translate(new Vector3(0f, 0f, speed * Time.deltaTime));
    }

    IEnumerator StopLaner()
    {
        yield return new WaitForSeconds(1);
        body.velocity = new Vector3(-speed, 0, 0);
        inchange = false;
    }
    
}
