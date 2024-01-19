using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_camScript : MonoBehaviour
{

    public float distance = 5f;
    public float smoothSpeed = 0.125f;
    public float height = 2f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;  // Bereken de gewenste positie van de camera
        //transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // Maak een soepele overgang naar de gewenste positie
        //transform.LookAt(target.position);µ

        transform.position = new Vector3(target.position.x + distance, 3.6f, target.position.z);
    }
}
