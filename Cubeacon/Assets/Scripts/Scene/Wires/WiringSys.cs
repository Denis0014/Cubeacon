using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WiringSys : MonoBehaviour
{
    public bool signal_type;
    public bool activated;
    public List<GameObject> links;
    public Vector3 start_pos;
    public List<Vector3> end_poses;
    public Material material;
    protected List<GameObject> wires;
    protected Color32 activated_wires_color = new Color32(128, 48, 48, 255);
    protected Color32 deactivated_wires_color = new Color32(32, 96, 32, 255);
    protected Color32 activated_color = new Color32(0, 255, 0, 255);
    protected Color32 deactivated_color = new Color32(255, 255, 255, 255);

    virtual protected void Start()
    {
        wires = new List<GameObject>(links.Count);
        for (int i = 0; i < links.Count; i++)
        {
            GameObject w = new GameObject("wire");
            w.transform.parent = this.gameObject.transform;
            LineRenderer l = w.AddComponent<LineRenderer>();
            l.startWidth = 0.1f;
            l.endWidth = 0.1f;
            l.material = material;
            l.startColor = Color.white;
            l.endColor = Color.white;
            l.textureMode = LineTextureMode.Tile;
            //Debug.Log(links[i].transform.position);
            l.SetPositions(new Vector3[2] { transform.position + start_pos, links[i].transform.position + end_poses[i] });
            wires.Add(w);
        }
    }

    virtual protected void Update()
    {
        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = activated_color;
            for (int i = 0; i < links.Count; i++)
            {
                links[i].GetComponent<WiringSys>().activated = true;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", activated_wires_color);
            }
            if (signal_type)
                activated = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = deactivated_color;
            for (int i = 0; i < links.Count; i++)
            {
                links[i].GetComponent<WiringSys>().activated = false;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", deactivated_wires_color);
            }
            if (!signal_type)
                activated = true;
        }
    }
}