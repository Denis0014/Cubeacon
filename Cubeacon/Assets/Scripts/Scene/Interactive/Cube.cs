using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : InteractiveObject
{
    protected override AudioSource GetAudioSource()
    {
        Object[] sources = FindObjectsOfType(typeof(AudioSource));

        foreach (AudioSource source in sources)
            if (source.name.Equals("BlockSound"))
                return source;

        Debug.Log("В сцене нет объекта BlockSound!");
        return null;
    }
}
