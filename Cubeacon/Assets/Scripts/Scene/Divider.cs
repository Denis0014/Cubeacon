using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : Reflective
{
    private RayRenderer r2;

    void Start()
    {
        LineRenderer l = gameObject.AddComponent<LineRenderer>();
        l.useWorldSpace = true;
        r = new RayRenderer(xSpeed, ySpeed, l, transform);

        r2 = new RayRenderer(xSpeed, -ySpeed, l, transform);
    }

    void Update()
    {
        if (isReflect)
        {
            r.Width(0.1f);
            r.EmitRay();
            r2.EmitRay();
        }

        else
        {
            r.Width(0f);
        }

        isReflect = false;
    }
}
