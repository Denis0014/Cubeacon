using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public int levelNumber;         //TODO: ����� ����� ���� �� ������. ����� ������� ��������� ����� � ����������� �� ������, ������� ����� ����� ��������� �������.
    bool alreadyFinished = false;

    public void FinishLevel()
    {
        if (alreadyFinished)
            return;

        alreadyFinished = true;

        GetComponent<SpriteRenderer>().color = Color.white;

        SaveLoadSystem.Save(levelNumber);   //TODO: ����� ����� ���� �� ������. ����� ������� ��������� ����� � ����������� �� ������, ������� ����� ����� ��������� �������.
    }
}
