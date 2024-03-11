using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWall : WiringSys
{
    override protected void Start()
    {
        activated_color = new Color32(0, 150, 255, 150);
        deactivated_color = new Color32(150, 150, 150, 255);
        gameObject.GetComponent<SpriteRenderer>().size = new Vector2(0.3f, 1.2f);
        base.Start();
    }

    override protected void Update()
    {
        if (activated && gameObject.layer == LayerMask.NameToLayer("Blocks light"))
        {
            gameObject.layer = LayerMask.NameToLayer("Passes light");
        }
        else if (!activated && gameObject.layer == LayerMask.NameToLayer("Passes light"))
        {
            gameObject.layer = LayerMask.NameToLayer("Blocks light");
        }
        base.Update();
    }

    protected override void Update_pos()
    {
    }
}
