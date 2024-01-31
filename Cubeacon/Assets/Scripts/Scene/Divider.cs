using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : Reflective
{
    private RayRenderer r2;

    protected override void CreateRays()
    {
        base.CreateRays();

        GameObject rayObject2 = Instantiate(rayPrefab, transform.position, Quaternion.identity);
        r2 = rayObject2.GetComponent<RayRenderer>();
        r2.SetSpeed(xSpeed, -ySpeed);
    }

    protected override void Update()
    {
        SetRayPosition();
        EmitRay();
    }

    protected override void SetRayPosition()
    {
        base.SetRayPosition();
        r2.SetPosition(transform);
    }

    protected override void EmitRay()
    {
        base.EmitRay();

        if (isReflect)
        {
            r2.Width(0.1f);
            r2.EmitRay();
        }

        else
        {
            r2.Width(0f);
        }
    }
}
