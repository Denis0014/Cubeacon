using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WiringSys : MonoBehaviour
{
    public bool signal_type;
    public bool activated;
    [Space]
    public List<GameObject> links;
    public Vector3 start_pos;
    public List<Vector3> end_poses;
    protected List<GameObject> wires;
    protected Color32 activated_wires_color = new Color32(128, 48, 48, 255);
    protected Color32 deactivated_wires_color = new Color32(32, 96, 32, 255);
    protected Color32 activated_color = new Color32(0, 255, 0, 255);
    protected Color32 deactivated_color = new Color32(255, 255, 255, 255);
    [Space]
    public Sprite sprite_off;
    public Sprite sprite_on;

    virtual protected void Start()
    {
        if (sprite_off && sprite_on)
        {
            activated_color = new Color32(255, 255, 255, 255);
            deactivated_color = new Color32(255, 255, 255, 255);
        }
        wires = new List<GameObject>(links.Count);
        for (int i = 0; i < links.Count; i++)
        {
            GameObject w = new GameObject("wire");
            w.transform.parent = this.gameObject.transform;
            LineRenderer l = w.AddComponent<LineRenderer>();
            l.startWidth = 0.1f;
            l.endWidth = 0.1f;
            l.startColor = Color.white;
            l.endColor = Color.white;
            l.textureMode = LineTextureMode.Tile;
            //Debug.Log(links[i].transform.position);
            l.SetPositions(new Vector3[2] { transform.position + start_pos, links[i].transform.position + end_poses.ElementAtOrDefault(i) });
            wires.Add(w);
        }
    }

    virtual protected void Update()
    {
        Update_pos();
        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = activated_color;
            if (sprite_on)
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite_on;
            for (int i = 0; i < links.Count; i++)
            {
                if (links[i].IsDestroyed())
                {
                    Destroy(wires[i]);
                    links.RemoveAt(i);
                    wires.RemoveAt(i);
                    return;
                }
                links[i].GetComponent<WiringSys>().activated = true;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", activated_wires_color);
            }
            if (signal_type)
                activated = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = deactivated_color;
            if (sprite_off)
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite_off;
            for (int i = 0; i < links.Count; i++)
            {
                if (links[i].IsDestroyed())
                {
                    Destroy(wires[i]);
                    links.RemoveAt(i);
                    wires.RemoveAt(i);
                    return;
                }
                links[i].GetComponent<WiringSys>().activated = false;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", deactivated_wires_color);
            }
            if (!signal_type)
                activated = true;
        }
    }

    virtual protected void Update_pos()
    {
        for (int i = 0; i < end_poses.Count; i++)
        {
            wires[i].GetComponent<LineRenderer>().SetPositions(new Vector3[2] { transform.position + start_pos, links[i].transform.position + end_poses[i] });
        }
    }
}