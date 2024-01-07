using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int index = 0;
        Vector3 Newpos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = Newpos;
    }
}
