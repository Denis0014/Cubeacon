using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    private float spawnTime = 0;

    public GameObject objectToSpawn;
    void Start()
    {

    }

    void Update()
    {
        if (spawnTime > 0.001)
        {
            GameObject ray = (GameObject)Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
            ray.transform.parent = transform;
            spawnTime = 0;
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
    }
}
