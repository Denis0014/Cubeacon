using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
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

    public bool tryToMove(Vector2 playerDirection)
    {
        if (canBeMoved(playerDirection))
        {
            rb.MovePosition(rb.position + playerDirection);
            return true;
        }
        return false;
    }

   private bool canBeMoved(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 1, LayerMask.GetMask("Wall"));
        return hit.collider == null;
    }
}
