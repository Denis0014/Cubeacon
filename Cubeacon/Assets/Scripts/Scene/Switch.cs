using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activated;
    public List<GameObject> links;
    public Material material;
    private List<GameObject> wires;

    void Start()
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
            l.SetPositions(new Vector3[2] { transform.position, links[i].transform.position });
            wires.Add(w);
        }
    }

    void Update()
    {
        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            for (int i = 0; i < links.Count; i++)
            {
                links[i].GetComponent<Switch>().activated = true;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", new Color32(128, 48, 48, 0));
            }
            activated = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            for (int i = 0; i < links.Count; i++)
            {
                links[i].GetComponent<Switch>().activated = false;
                wires[i].GetComponent<LineRenderer>().material.SetColor("_EmissionColor", new Color32(32, 96, 32, 0));
            }
        }
    }
}
