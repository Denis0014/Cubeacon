using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflective : Beacon
{
    public bool isReflect;

    void Start()
    {
        LineRenderer l = gameObject.AddComponent<LineRenderer>();
        l.useWorldSpace = true;
        r = new RayRenderer(xSpeed, ySpeed, l, transform);
    }

    void Update()
    {

        if (isReflect)
        {
            r.Width(0.1f);
            r.EmitRay();
        }

        else
        {
            r.Width(0f);
        }

        isReflect = false;
    }

    virtual public void ReflectRay(RayRenderer incomingRay)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        isReflect = true;
        int s = (spriteRenderer.flipX == spriteRenderer.flipY) ? 1 : -1;

        r.Reflect(incomingRay, s);
    }
}
