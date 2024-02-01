using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflective : Beacon
{
    public bool isReflect;

    protected override void Update()
    {
        base.Update();
        isReflect = false;
    }

    protected override void EmitRay()
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
    }

    public virtual void ReflectRay(RayRenderer incomingRay)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        isReflect = true;

        if (spriteRenderer.flipX == spriteRenderer.flipY)
            r.ReflectLeft(incomingRay);
        else
            r.ReflectRight(incomingRay);

        r.SetPosition(transform);
    }
}
