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
            tryToMove(new Vector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tryToMove(new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            tryToMove(new Vector2(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            tryToMove(new Vector2(1, 0));
        }
    }

    private void tryToMove(Vector2 direction)
    {
        checkForAnObstacle(direction);
        rb.MovePosition(rb.position + direction * speed);
    }

    private void checkForAnObstacle(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 1, LayerMask.GetMask("Interactive"));
        if (hit.collider != null)
        {
            Cube cube = hit.collider.GetComponent<Cube>();
            cube.interactWithPlayer(direction);
        }
    }
}