using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Undo : MonoBehaviour
{
    public Stack<Dictionary<GameObject, Vector3>> history;

    public Undo()
    {
        history = new Stack<Dictionary<GameObject, Vector3>>();
    }

    private static Undo instance;
    public static Undo Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Undo>();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(this + ": походу " + instance.gameObject + "ведёт историю за меня!");
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (history.Count > 0)
            {
                var objects = history.Pop();
                foreach (var obj in objects.Keys)
                {
                    if (obj.activeSelf)
                    {
                        obj.transform.position = objects[obj];
                    }
                    else
                    {
                        obj.SetActive(true);
                        obj.GetComponentInChildren<Animator>().SetTrigger("back");
                    }
                }
            }
        }
    }
}
