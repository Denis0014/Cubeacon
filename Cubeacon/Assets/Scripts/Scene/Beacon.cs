using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    protected LineRenderer l;

    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();
        l.startWidth = 0.1f;
        l.endWidth = 0.1f;
        l.useWorldSpace = true;
    }
    void Update()
    {
        EmitRay();
    }

    protected void EmitRay()
    {
        RaycastHit2D hit = GetClosestObjectHit();

        if (hit.collider != null)
        {
            l.SetPositions(new Vector3[2]
            {
                transform.position,
                transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0) + new Vector3(Math.Sign(xSpeed) * hit.distance, Math.Sign(ySpeed) * hit.distance, 0)
            });

            if (hit.collider.gameObject.tag == "Mirror")
            {
                Reflective reflect = hit.collider.gameObject.GetComponent<Reflective>();
                SpriteRenderer spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();

                reflect.isReflect = true;
                int s = (spriteRenderer.flipX == spriteRenderer.flipY) ? 1 : -1;

                reflect.xSpeed = ySpeed * s;
                reflect.ySpeed = xSpeed * s;
            }

            else if (hit.collider.gameObject.tag == "Finish")
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        else
        {
            l.SetPositions(new Vector3[2] { transform.position, transform.position + new Vector3(xSpeed, ySpeed, 0) * 1000 });
        }
    }
    
    private RaycastHit2D GetClosestObjectHit()
    {
        RaycastHit2D[] hits = GetAllHits();
    
        RaycastHit2D result = hits[0];
        float min = result.distance;

        foreach (var x in hits)
            if (x.collider != null && x.distance < min)
            {
                min = x.distance;
                result = x;
            }

        return result;
    }
    
    private RaycastHit2D[] GetAllHits()
    {
        return new RaycastHit2D[4] { GetHit("Wall"), GetHit("Interactive"), GetHit("Player"), GetHit("Light wall") };
    }

    private RaycastHit2D GetHit(string mask)
    {
        return Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask(mask));
    }
}
