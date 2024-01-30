using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public RayRenderer r;

    void Start()
    {
        LineRenderer l = gameObject.AddComponent<LineRenderer>();
        l.startWidth = 0.1f;
        l.endWidth = 0.1f;
        l.useWorldSpace = true;
        r = new RayRenderer(xSpeed, ySpeed, l, transform);
    }
    void Update()
    {
        r.EmitRay();
    }
}
