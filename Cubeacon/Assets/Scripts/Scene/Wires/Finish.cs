using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : WiringSys
{
    protected override void Start()
    {
        base.Start();
        /// Временно
        activated_color = new Color32(255, 255, 255, 255);
        deactivated_color = new Color32(0, 255, 0, 255);
    }

    protected override void Update()
    {
        base.Update();
        if (activated)
        {
            // TODO: Сохраниение
            // TODO: Спрайты
            Debug.Log("Win");
        }
    }
}
