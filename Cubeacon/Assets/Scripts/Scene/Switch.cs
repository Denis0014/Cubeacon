using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : WiringSys
{
    override protected void Start()
    {
        activate_color = new Color32(255, 255, 0, 255);
        inactive_color = new Color32(255, 255, 255, 255);
        base.Start();
    }
}
