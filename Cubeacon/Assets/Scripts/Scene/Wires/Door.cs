using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : WiringSys
{
    private Vector3 pos1;
    private Vector3 pos0;

    override protected void Start()
    {
        float angle = (float)((gameObject.transform.eulerAngles.z + 90) * Math.PI / 180);
        pos1 = gameObject.transform.position + new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f);
        pos0 = gameObject.transform.position;
        base.Start();
    }

    override protected void Update()
    {
        if (activated == signal_type)
        {
            gameObject.layer = 11;
            gameObject.transform.position = pos1;
        }
        else
        {
            gameObject.layer = 8;
            gameObject.transform.position = pos0;
        }
    }

    protected override void Update_pos()
    {
    }
}
