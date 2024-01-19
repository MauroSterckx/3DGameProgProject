using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision_lvl4 : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstakel")
        {
            Destroy(this.gameObject);

            Time.timeScale = 0;

            canvas.enabled = true;
        }
    }
}
