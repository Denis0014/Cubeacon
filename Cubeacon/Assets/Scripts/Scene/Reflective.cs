using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflective : Beacon
{
    public bool isReflect;

    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();
        l.useWorldSpace = true;
    }

    void Update()
    {

        if (isReflect)
        {
            l.startWidth = 0.1f;
            l.endWidth = 0.1f;
            EmitRay();
        }

        else
        {
            l.startWidth = 0f;
            l.endWidth = 0f;
        }

        isReflect = false;
    }
}
