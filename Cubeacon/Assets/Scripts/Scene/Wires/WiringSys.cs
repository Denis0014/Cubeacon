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
    public List<GameObject> parants;
    public List<GameObject> links;
    public Vector3 start_pos;
    public List<Vector3> end_poses;
    protected List<GameObject> wires;
    public GameObject wirePrefab;
    protected Color32 activated_wires_color = new Color32(128, 48, 48, 255);
    protected Color32 deactivated_wires_color = new Color32(32, 96, 32, 255);
    protected Color32 activated_color = new Color32(0, 255, 0, 255);
    protected Color32 deactivated_color = new Color32(255, 255, 255, 255);
    [Space]
    public Sprite sprite_off;
    public Sprite sprite_on;

    private void Awake()
    {
        parants = new List<GameObject>();
        activated = false;
    }

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
            links[i].GetComponent<WiringSys>().parants.Add(gameObject);
            GameObject w = Instantiate(wirePrefab, transform.position, Quaternion.identity);
            w.transform.parent = gameObject.transform;
            var l = w.GetComponent<LineRenderer>();
            //Debug.Log(links[i].transform.position);
            l.SetPositions(new Vector3[2] { transform.position + start_pos, links[i].transform.position + end_poses.ElementAtOrDefault(i) });
            wires.Add(w);
        }
    }

    virtual protected void Update()
    {
        Update_pos();
        bool exit = false;
        for (var i = 0; i < links.Count; i++)
        {
            if (!links[i].activeSelf)
            {
                wires[i].SetActive(false);
                links[i].SetActive(false);
                exit = true;
            }
            else
            {
                wires[i].SetActive(true);
            }
        }
        if (exit)
            return;
        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = activated_color;
            if (sprite_on)
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite_on;
            for (int i = 0; i < links.Count; i++)
            {
                var t = links[i].GetComponent<WiringSys>();
                int count = t.parants.Count(x => x != null && x.GetComponent<WiringSys>().activated);
                links[i].GetComponent<WiringSys>().activated = (count % 2 != 0) == t.signal_type;
                wires[i].GetComponent<LineRenderer>().startColor = activated_wires_color;
                wires[i].GetComponent<LineRenderer>().endColor = activated_wires_color;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = deactivated_color;
            if (sprite_off)
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite_off;
            for (int i = 0; i < links.Count; i++)
            {
                var t = links[i].GetComponent<WiringSys>();
                int count = t.parants.Count(x => x != null && x.GetComponent<WiringSys>().activated);
                links[i].GetComponent<WiringSys>().activated = (count % 2 == 0) != t.signal_type;
                wires[i].GetComponent<LineRenderer>().startColor = deactivated_wires_color;
                wires[i].GetComponent<LineRenderer>().endColor = deactivated_wires_color;
            }
        }
        activated = (parants.Count(x => x != null && x.GetComponent<WiringSys>().activated) % 2 != 0) == signal_type;
    }

    virtual protected void Update_pos()
    {
        for (int i = 0; i < end_poses.Count; i++)
        {
            wires[i].GetComponent<LineRenderer>().SetPositions(new Vector3[2] { transform.position + start_pos, links[i].transform.position + end_poses[i] });
        }
    }
}