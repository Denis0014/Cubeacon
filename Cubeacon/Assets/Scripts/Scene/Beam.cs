using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;
    public float xSpeed;
    public float ySpeed;
    public float lifeTime;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        transform.Translate(xSpeed, ySpeed, 0);
        if (isBlocked())
            Destroy(transform.gameObject);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(transform.gameObject);

        Finish();
        
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        if (hit.collider == null)
            return;

        switch (hit.collider.gameObject.tag)
        {
            case "MirrorRU":
                if (xSpeed < 0 && ySpeed == 0)
                {
                    ySpeed = -xSpeed;
                    xSpeed = 0;
                }
                else if (xSpeed == 0 && ySpeed < 0)
                {
                    xSpeed = -ySpeed;
                    ySpeed = 0;
                }
                break;

            case "MirrorLU":
                if (xSpeed > 0 && ySpeed == 0)
                {
                    ySpeed = xSpeed;
                    xSpeed = 0;
                }
                else if (xSpeed == 0 && ySpeed < 0)
                {
                    xSpeed = ySpeed;
                    ySpeed = 0;
                }
                break;

            case "MirrorRD":
                if (xSpeed < 0 && ySpeed == 0)
                {
                    ySpeed = xSpeed;
                    xSpeed = 0;
                }
                else if (xSpeed == 0 && ySpeed > 0)
                {
                    xSpeed = ySpeed;
                    ySpeed = 0;
                }
                break;

            case "MirrorLD":
                if (xSpeed > 0 && ySpeed == 0)
                {
                    ySpeed = -xSpeed;
                    xSpeed = 0;
                }
                else if (xSpeed == 0 && ySpeed > 0)
                {
                    xSpeed = -ySpeed;
                    ySpeed = 0;
                }
                break;
        }
        
    }

    private bool isBlocked()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Wall"));
        if (hit.collider == null)
            hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        if (hit.collider == null)
            hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Player"));
        if (hit.collider == null)
            hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Light wall"));
        return hit.collider != null && hit.collider.gameObject.tag == "not a mirror";
    }

    private void Finish()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Wall"));
        if (hit.collider != null && hit.collider.gameObject.tag == "Finish")
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(transform.gameObject);
        }
    }
}
