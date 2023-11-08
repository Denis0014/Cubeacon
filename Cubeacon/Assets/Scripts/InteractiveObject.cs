using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool tryToMove(Vector2 direction)
    {
        if (isBlockedByWall(direction))
            return false;

        InteractiveObject objectInFront = InteractiveObjectOnTheWay(direction);
        if (objectInFront == null || objectInFront.tryToMove(direction))
        {
            rb.MovePosition(rb.position + direction);
            return true;
        }

        return false;
    }

    private bool isBlockedByWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 1, LayerMask.GetMask("Wall"));
        return hit.collider != null;
    }

    private InteractiveObject InteractiveObjectOnTheWay(Vector2 direction)
    {
        Vector2 rayStart = rb.position + new Vector2(0.5f, 0.5f) * direction;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, direction, 1, LayerMask.GetMask("Interactive"));
        if (hit.collider != null)
        {
            InteractiveObject obj = hit.collider.GetComponent<InteractiveObject>();
            return obj;
        }

        return null;
    }
}
