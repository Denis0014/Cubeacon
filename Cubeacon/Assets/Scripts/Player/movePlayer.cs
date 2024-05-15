using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movePlayer : InteractiveObject
{
    public ParticleSystem dust;
    public Animator animator;
    public bool PauseMenu;
    private SpriteRenderer sr;
    private Undo undo;

    void Start()
    {
        Time.timeScale = 1f;
        sr = GetComponent<SpriteRenderer>();
        undo = Undo.Instance;
    }

    void Update()
    {
        if (!PauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMoveUp();
                
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMoveLeft();
                
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMoveDown();
                
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMoveRight();
                
            }
        }
    }

    private void TryMoveUp()
    {
        if (TryToMove(new Vector2(0, 1), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Up");
            CreateDust();
        }
    }

    private void TryMoveLeft()
    {
        if (TryToMove(new Vector2(-1, 0), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Go");
            CreateDust();
        }
        sr.flipX = true;
    }

    private void TryMoveDown()
    {
        if (TryToMove(new Vector2(0, -1), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Down");
            CreateDust();
        }
    }

    private void TryMoveRight()
    {
        if (TryToMove(new Vector2(1, 0), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Go");
            CreateDust();
        }
        sr.flipX = false;
    }
    void CreateDust()
    {
        dust.Play();
    }
}