using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayRenderer : MonoBehaviour
{
    private float xSpeed;
    private float ySpeed;
    private LineRenderer l;

    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();
        var DefaultMaterial = new Material(Shader.Find("Unlit/Texture"));
        l.material = DefaultMaterial;
        l.material.SetColor("_EmissionColor", new Color32(255, 255, 255, 255));
        l.startWidth = 0.1f;
        l.endWidth = 0.1f;
        l.useWorldSpace = true;
    }

    public void SetSpeed(float xSpeed, float ySpeed)
    {
        this.xSpeed = xSpeed;
        this.ySpeed = ySpeed;
    }

    public void ReflectLeft(RayRenderer other)
    {
        xSpeed = other.ySpeed;
        ySpeed = other.xSpeed;
    }
    public void ReflectRight(RayRenderer other)
    {
        xSpeed = -other.ySpeed;
        ySpeed = -other.xSpeed;
    }

    public void SetPosition(Transform transform)
    {
        this.transform.position = transform.position;
    }

    public void EmitRay()
    {
        RaycastHit2D hit = GetClosestObjectHit();

        if (hit.collider == null)
        {
            DrawRayToInfinity();
        }

        else
        {
            DrawRayToObstacle(hit);

            var obj = hit.collider.gameObject;
            
            if (obj == null) 
            {
                return;
            }

            if (obj.layer == LayerMask.NameToLayer("Mirror"))
            {
                Reflective reflect = obj.GetComponent<Reflective>();
                reflect.ReflectRay(this);
            }

            else if (obj.layer == LayerMask.NameToLayer("Switch"))
            {
                var hasntRay = obj.GetComponent<Switch>().parants.FindLast(x => x.GetComponent<RaySignal>() != null);
                if (hasntRay)
                    hasntRay.GetComponent<RaySignal>().activated = true;
            }
        }

    }

    private RaycastHit2D GetClosestObjectHit()
    {
        string[] layers = { "Blocks light", "Mirror", "Switch" };
        return Physics2D.Raycast(transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0), new Vector3(xSpeed, ySpeed, 0), Mathf.Infinity, LayerMask.GetMask(layers));
    }

    private void DrawRayToObstacle(RaycastHit2D hit)
    {
        l.SetPositions(new Vector3[2]
        {
            transform.position,
            transform.position + new Vector3(Math.Sign(xSpeed) * 0.5f, Math.Sign(ySpeed) * 0.5f, 0) + new Vector3(Math.Sign(xSpeed) * hit.distance, Math.Sign(ySpeed) * hit.distance, 0)
        });
    }

    private void DrawRayToInfinity()
    {
        l.SetPositions(new Vector3[2] { transform.position, transform.position + new Vector3(xSpeed, ySpeed, 0) * 1000 });
    }

    public void Width(float width)
    {
        l.startWidth = width;
        l.endWidth = width;
    }
}
