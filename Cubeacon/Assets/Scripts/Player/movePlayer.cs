using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, new Vector2(0, 1), 1, LayerMask.GetMask("Interactive"));
            if (hit.collider != null)
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                cube.interactWithPlayer(new Vector2(0, 1));
            }
            rb.MovePosition(rb.position + new Vector2(0, 1) * speed);
            
                
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + new Vector2(-1, 0) * speed);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + new Vector2(0, -1) * speed);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + new Vector2(1, 0) * speed);
        }
    }
}