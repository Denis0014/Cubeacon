using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : InteractiveObject
{
    public float speed = 1; //Нам это точно нужно?

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
}