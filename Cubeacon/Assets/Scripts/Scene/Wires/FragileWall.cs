using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileWall : WiringSys
{

    public Animator animator;

    override protected void Start()
    {
        activated_color = new Color32(255, 255, 0, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
    }

    override protected void Update()
    {
        if (activated)
        {
            animator.SetBool("go", true);
            Destroy(gameObject, 1);
        }
    }
}
