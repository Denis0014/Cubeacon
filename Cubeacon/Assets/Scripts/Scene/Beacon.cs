using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    private float spawnTime = 0;
    public float xSpeed;
    public float ySpeed;

    public GameObject objectToSpawn;

    void Update()
    {
        if (spawnTime > 0.0001)
        {
            GameObject ray = (GameObject)Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
            ray.transform.parent = transform;
            ray.GetComponent<Beam>().xSpeed = xSpeed;
            ray.GetComponent<Beam>().ySpeed = ySpeed;
            spawnTime = 0;
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
    }
}
