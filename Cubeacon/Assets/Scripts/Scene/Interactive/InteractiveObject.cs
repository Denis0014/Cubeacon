using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;
    private int interactiveLayers;
    public bool noclip;

    void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        interactiveLayers = LayerMask.GetMask("Blocks light", "Mirror", "Passes light", "Switch");
    }

    protected bool tryToMove(Vector2 direction)
    {
        
        if (!noclip && isBlockedByWall(direction))
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
        Vector2 rayStart = rb.position + new Vector2(0.5f, 0.5f) * direction;
        RaycastHit2D hit = Physics2D.Raycast(rayStart, direction, 1, interactiveLayers);

        if (hit.collider != null && hit.collider.tag == "Blocks movement")
            return true;
        return false;
    }

    private InteractiveObject InteractiveObjectOnTheWay(Vector2 direction)
    {
        Vector2 rayStart = rb.position + new Vector2(0.6f, 0.6f) * direction;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, direction, 0.5f, interactiveLayers);
        if (hit.collider != null && hit.collider.tag == "Moveable")
        {
            InteractiveObject obj = hit.collider.GetComponent<InteractiveObject>();
            return obj;
        }

        return null;
    }
}
