using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class FragileWall : WiringSys
{

    public Animator animator;
    public float timer1;
    public float timer2;
    private Undo undo;

    protected override void Update_pos() { }

    override protected void Start()
    {
        activated_color = new Color32(255, 255, 0, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
        timer1 = 1f;
        timer2 = 1f;
        undo = FindObjectOfType<Undo>();
    }

    override protected void Update()
    {
        if (activated)
        {
            if (timer2 > 0)
            {
                timer2 -= Time.deltaTime;
                return;
            }
            if (timer1 == 1f)
            {
                animator.StartRecording(5);
                animator.SetTrigger("go");
            }
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                undo.history.Peek().Add(gameObject, transform.position);
                gameObject.SetActive(false);
                timer2 = 1f;
                timer1 = 1;
            }
        }
        else
        {
            timer2 = 1f;
            timer1 = 1;
        }
    }
}
