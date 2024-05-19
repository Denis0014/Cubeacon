using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTextureScale = transform.parent.localScale;
    }
}
