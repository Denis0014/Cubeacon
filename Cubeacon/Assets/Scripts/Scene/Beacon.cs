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

    protected virtual void Start()
    {
        CreateRays();
    }

    protected virtual void CreateRays()
    {
        GameObject rayObject = Instantiate(rayPrefab, transform.position, Quaternion.identity);
        r = rayObject.GetComponent<RayRenderer>();
        r.SetSpeed(xSpeed, ySpeed);
    }

    protected virtual void Update()
    {
        SetRayPosition();
        EmitRay();
    }

    protected virtual void SetRayPosition()
    {
        r.SetPosition(transform);
    }

    protected virtual void EmitRay()
    {
        r.EmitRay();
    }
}
