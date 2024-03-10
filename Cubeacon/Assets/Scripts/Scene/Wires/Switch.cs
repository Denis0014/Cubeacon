using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : WiringSys
{
    override protected void Start()
    {
        activated_color = new Color32(255, 255, 0, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
        base.Start();
    }
}
