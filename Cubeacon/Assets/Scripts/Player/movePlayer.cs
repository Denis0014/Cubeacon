using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : InteractiveObject
{
    public Animator animator;
    public bool PauseMenu;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (tryToMove(new Vector2(0, 1)))
                    animator.SetTrigger("Up");
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (tryToMove(new Vector2(-1, 0)))
                    animator.SetTrigger("Go");
                sr.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                tryToMove(new Vector2(0, -1));
                animator.SetTrigger("Down");
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tryToMove(new Vector2(1, 0)))
                    animator.SetTrigger("Go");
                sr.flipX = false;
            }
        }

    }
}