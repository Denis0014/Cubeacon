using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : Reflective
{
    public RayRenderer r2;

    protected void EmitSecondRay()
    {

    }

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
            r.l.startWidth = 0.1f;
            r.l.endWidth = 0.1f;
            r.EmitRay();
            r2.EmitRay();
        }

        else
        {
            r.l.startWidth = 0f;
            r.l.endWidth = 0f;
        }

        isReflect = false;
    }
}
