using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            Debug.LogWarning(this + ": ������ " + instance.gameObject + "���� ������� �� ����!");
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (history.Count > 0)
            {
                var objects = history.Pop();
                foreach (var obj in objects.Keys)
                    obj.transform.position = objects[obj];
            }
        }
    }
}
