using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FragileWall : WiringSys
{

    public Animator animator;
    public float timer;

    override protected void Start()
    {
        activated_color = new Color32(255, 255, 0, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
        timer = 2;
    }

    override protected void Update()
    {
        if (activated)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                animator.SetBool("go", true);
                Destroy(gameObject, 1);
            }
            activated = false;
        }
    }
}
