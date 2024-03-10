using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : WiringSys
{
    private Vector3 pos1;
    private Vector3 pos0;
    override protected void Start()
    {
        pos1 = gameObject.transform.position + new Vector3(0f, 0.4f, 0f);
        pos0 = gameObject.transform.position;
        base.Start();
    }

    override protected void Update()
    {
        if (activated == signal_type)
        {
            gameObject.layer = 11;
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(0.3f, 0.3f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0, 0);
            gameObject.transform.position = pos1;
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.layer = 8;
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(0.3f, 1f);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.3f, 1f);
            gameObject.transform.position = pos0;
            gameObject.tag = "Blocks movement";
        }
    }
}
