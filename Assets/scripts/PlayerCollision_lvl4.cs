using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision_lvl4 : MonoBehaviour
{
    public Canvas canvas;
    public Canvas canvaske;
    public GameObject explosionParticle;

    public TMP_Text textje;

    static int punten = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        canvaske.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            canvaske.enabled = true;
        }
        if (Time.timeScale == 0)
        {
            canvaske.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstakel")
        {
            Destroy(this.gameObject);

            Time.timeScale = 0;

            canvas.enabled = true;
        }

        if (collision.gameObject.tag == "pickup")
        {
            Debug.Log("baterij opgepakt");
            punten++;
            textje.text = "score: " + punten;
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
