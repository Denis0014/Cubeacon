using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    protected RayRenderer r;
    public GameObject rayPrefab;

    void Start()
    {
        CreateRays();
    }

    protected virtual void CreateRays()
    {
        GameObject rayObject = Instantiate(rayPrefab, transform.position + new Vector3(0, 0, 1), Quaternion.identity);
        r = rayObject.GetComponent<RayRenderer>();
        r.SetSpeed(xSpeed, ySpeed);
    }

    protected virtual void Update()
    {
        EmitRay();
    }

    protected virtual void EmitRay()
    {
        r.EmitRay();
    }
}
