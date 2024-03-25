using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : WiringSys
{
    private Vector3 pos1;
    private Vector3 pos0;
    public GameObject ToDestroy;
    override protected void Start()
    {
        pos1 = gameObject.transform.position + new Vector3(0f, 1f, 0f);
        pos0 = gameObject.transform.position;
        base.Start();
    }

    override protected void Update()
    {
        if (activated == signal_type)
        {
            gameObject.layer = 11;
            gameObject.transform.position = pos1;
            gameObject.tag = "Untagged";
            Destroy(ToDestroy);
        }
        else
        {
            gameObject.layer = 8;
            gameObject.transform.position = pos0;
            gameObject.tag = "Blocks movement";
        }
    }

    protected override void Update_pos()
    {
    }
}
