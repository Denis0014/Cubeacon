using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private bool isBlocked()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, transform.position, 1, LayerMask.GetMask("Wall"));
        if (hit.collider == null)
            hit = Physics2D.Raycast(rb.position, transform.position, 1, LayerMask.GetMask("Interactive"));
        if (hit.collider == null)
            hit = Physics2D.Raycast(rb.position, transform.position, 1, LayerMask.GetMask("Player"));
        return hit.collider != null && hit.collider.gameObject.tag == "not a mirror";
    }

    void Update()
    {
        transform.Translate(0.05f, 0, 0);
        if (isBlocked())
            Destroy(transform.gameObject);
    }
}
