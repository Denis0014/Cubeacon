using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public int levelNumber;         //TODO: Этого здесь быть не должно. Нужно создать отдельный класс с информацией об уровне, который также будет завершать уровень.
    bool alreadyFinished = false;

    public void FinishLevel()
    {
        if (alreadyFinished)
            return;

        alreadyFinished = true;

        GetComponent<SpriteRenderer>().color = Color.white;

        SaveLoadSystem.Save(levelNumber);   //TODO: Этого здесь быть не должно. Нужно создать отдельный класс с информацией об уровне, который также будет завершать уровень.
    }
}
