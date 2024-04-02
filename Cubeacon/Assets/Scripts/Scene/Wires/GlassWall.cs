using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWall : WiringSys
{
    public float timer1;
    public float timer2;

    override protected void Start()
    {
        activated_color = new Color32(0, 150, 255, 150);
        deactivated_color = new Color32(150, 150, 150, 255);
        timer1 = 0.1f;
        timer2 = 0.1f;
        base.Start();
    }

    override protected void Update()
    {
        if (activated && gameObject.layer == LayerMask.NameToLayer("Blocks light"))
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            { 
                timer1 = 0.1f;
                gameObject.layer = LayerMask.NameToLayer("Passes light");
            }
        }
        else if (!activated && gameObject.layer == LayerMask.NameToLayer("Passes light"))
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                timer2 = 0.1f;
                gameObject.layer = LayerMask.NameToLayer("Blocks light");
            }
        }
        base.Update();
    }

    protected override void Update_pos()
    {
    }
}
