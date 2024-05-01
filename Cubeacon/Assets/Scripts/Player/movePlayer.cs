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
                if (TryToMove(new Vector2(0, 1), new Dictionary<GameObject, Vector3>(), undo))
                    animator.SetTrigger("Up");
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (TryToMove(new Vector2(-1, 0), new Dictionary<GameObject, Vector3>(), undo))
                    animator.SetTrigger("Go");
                sr.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (TryToMove(new Vector2(0, -1), new Dictionary<GameObject, Vector3>(), undo))
                    animator.SetTrigger("Down");
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (TryToMove(new Vector2(1, 0), new Dictionary<GameObject, Vector3>(), undo))
                    animator.SetTrigger("Go");
                sr.flipX = false;
            }
        }

    }
}