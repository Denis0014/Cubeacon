using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Switch : WiringSys
{
    private GameObject ray;
    public float timer;

    override protected void Start()
    {
        timer = 0.1f;
        activated_color = new Color32(255, 255, 0, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
        ray = new("raySignal");
        ray.transform.parent = gameObject.transform;
        var raySignal = ray.AddComponent<RaySignal>();
        raySignal.signal_type = true;
        raySignal.activated = false;
        parants.Add(ray);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (ray.GetComponent<RaySignal>().activated)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ray.GetComponent<RaySignal>().activated = false;
                timer = 0.1f;
            }
        }
    }

    protected override void Update_pos()
    {
    }
}
