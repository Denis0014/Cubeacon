using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movePlayer : InteractiveObject
{
    public Animator animator;
    public bool PauseMenu;
    private SpriteRenderer sr;
    private Undo undo;
    private AudioSource audioSource;

    void Start()
    {
        Time.timeScale = 1f;
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
        }
    }

    private void TryMoveLeft()
    {
        if (TryToMove(new Vector2(-1, 0), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Go");
            audioSource.Play();
        }
        sr.flipX = true;
    }

    private void TryMoveDown()
    {
        if (TryToMove(new Vector2(0, -1), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Down");
            audioSource.Play();
        }
    }

    private void TryMoveRight()
    {
        if (TryToMove(new Vector2(1, 0), new Dictionary<GameObject, Vector3>(), undo))
        {
            animator.SetTrigger("Go");
            audioSource.Play();
        }
        sr.flipX = false;
    }
}