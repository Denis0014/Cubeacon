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

    private bool isMirrorRU()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        return hit.collider != null && hit.collider.gameObject.tag == "MirrorRU";
    }

    private bool isMirrorLU()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        return hit.collider != null && hit.collider.gameObject.tag == "MirrorLU";
    }

    private bool isMirrorRD()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        return hit.collider != null && hit.collider.gameObject.tag == "MirrorRD";
    }

    private bool isMirrorLD()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector3(xSpeed, ySpeed, 0), 0.05f, LayerMask.GetMask("Interactive"));
        return hit.collider != null && hit.collider.gameObject.tag == "MirrorLD";
    }

    void Update()
    {
        transform.Translate(xSpeed, ySpeed, 0);
        if (isBlocked())
            Destroy(transform.gameObject);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(transform.gameObject);
        if (isMirrorRU())
        {
            //Debug.Log("isMirrorRU");
            if (xSpeed < 0 && ySpeed == 0)
            {
                ySpeed = -xSpeed;
                xSpeed = 0;
                //Debug.Log("TurnRU");
                return;
            }
            if (xSpeed == 0 && ySpeed < 0)
            {
                xSpeed = -ySpeed;
                ySpeed = 0;
                //Debug.Log("TurnUR");
                return;
            }
        }
        if (isMirrorLU())
        {
            //Debug.Log("isMirrorLU");
            if (xSpeed > 0 && ySpeed == 0)
            {
                ySpeed = xSpeed;
                xSpeed = 0;
                //Debug.Log("TurnLU");
                return;
            }
            if (xSpeed == 0 && ySpeed < 0)
            {
                xSpeed = ySpeed;
                ySpeed = 0;
                //Debug.Log("TurnUL");
                return;
            }
        }
        if (isMirrorRD())
        {
            //Debug.Log("isMirrorRD");
            if (xSpeed < 0 && ySpeed == 0)
            {
                ySpeed = xSpeed;
                xSpeed = 0;
                //Debug.Log("TurnRD");
                return;
            }
            if (xSpeed == 0 && ySpeed > 0)
            {
                xSpeed = ySpeed;
                ySpeed = 0;
                //Debug.Log("TurnDR");
                return;
            }
        }
        if (isMirrorLD())
        {
            //Debug.Log("isMirrorLD");
            if (xSpeed > 0 && ySpeed == 0)
            {
                ySpeed = -xSpeed;
                xSpeed = 0;
                //Debug.Log("TurnLD");
                return;
            }
            if (xSpeed == 0 && ySpeed > 0)
            {
                xSpeed = -ySpeed;
                ySpeed = 0;
                //Debug.Log("TurnDL");
                return;
            }
        }
    }
}
