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

    protected RaycastHit2D GetMinDist(RaycastHit2D hit0, RaycastHit2D hit1, RaycastHit2D hit2, RaycastHit2D hit3)
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        if (hit0.collider != null)
            hits.Add(hit0);
        if (hit1.collider != null)
            hits.Add(hit1);
        if (hit2.collider != null)
            hits.Add(hit2);
        if (hit3.collider != null)
            hits.Add(hit3);
        float min = float.MaxValue;
        RaycastHit2D result = Physics2D.Raycast(transform.position, new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, 99);
        foreach (var x in hits)
            if (x.distance < min)
            {
                min = x.distance;
                result = x;
            }
        return result;
    }

    protected void Ray()
    {
        RaycastHit2D hit0 = Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask("Wall"));
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask("Interactive"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask("Player"));
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask("Light wall"));
        RaycastHit2D hit = GetMinDist(hit0, hit1, hit2, hit3);
        if (hit.collider != null)
        {
            l.SetPositions(new Vector3[2]
            {
                transform.position,
                transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0) + new Vector3(Math.Sign(xSpeed) * hit.distance, Math.Sign(ySpeed) * hit.distance, 0)
            });
            if (hit.collider.gameObject.tag == "Mirror")
            {
                hit.collider.gameObject.GetComponent<Reflect>().isReflect = true;
                int s = hit.collider.gameObject.GetComponent<SpriteRenderer>().flipX == hit.collider.gameObject.GetComponent<SpriteRenderer>().flipY ? 1 : -1;
                hit.collider.gameObject.GetComponent<Reflect>().xSpeed = ySpeed * s;
                hit.collider.gameObject.GetComponent<Reflect>().ySpeed = xSpeed * s;
            }
            if (hit.collider != null && hit.collider.gameObject.tag == "Finish")
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            //Debug.Log("Did Hit");
        }
        else
        {
            l.SetPositions(new Vector3[2] { transform.position, transform.position + new Vector3(xSpeed, ySpeed, 0) * 1000 });
            //Debug.Log("Did not Hit");
        }
    }

    void Update()
    {
        Ray();
    }
}
