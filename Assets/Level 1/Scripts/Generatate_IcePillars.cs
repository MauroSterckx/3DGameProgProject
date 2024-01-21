using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generatate_IcePillars : MonoBehaviour
{

    public GameObject icePillar;
    public float minX = -20f;
    public float maxX = 20f;
    public float minZ = 0f;
    public float maxZ = 20f;
    public float spawnInterval = 5f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Generate_IcePillars();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Generate_IcePillars();
            timer = 0f;
        }
    }


    void Generate_IcePillars()
    {
        // Zet de afstand naar volgende ijspilaar max 10 van waar de player nu is
        maxZ = GameObject.FindGameObjectWithTag("Player").transform.position.z + 20;

        // Genereer willekeurige X en Z coordinaten (Y blijft altijd 0)
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomZ = UnityEngine.Random.Range(minZ, maxZ);

        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ);

        GameObject newPillar = Instantiate(icePillar, spawnPosition, Quaternion.identity);

        // Genereer een willekeurige scale zodat de objecten verschillen in grootte
        float randomScale = UnityEngine.Random.Range(4f, 10f);
        newPillar.transform.localScale = new Vector3(randomScale, 1f, randomScale);

        Debug.Log("Ice Pillar generated on X:" + randomX  + " ,Y: " + randomZ);
    }
}
