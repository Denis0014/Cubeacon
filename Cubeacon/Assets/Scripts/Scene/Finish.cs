using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    bool alreadyFinished = false;

    public void FinishLevel()
    {
        if (alreadyFinished)
            return;

        alreadyFinished = true;

        GetComponent<SpriteRenderer>().color = Color.white;

        SaveLoadSystem.SaveThisLevel();
    }
}
