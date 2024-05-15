using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cheats : MonoBehaviour
{
    public void CompleteLevel()
    {
        SaveLoadSystem.SaveThisLevel();
        Debug.Log("Win");
        Debug.Log(SaveLoadSystem.LoadLevelsCompleted());

        LevelCompleteManager lcm = LevelCompleteManager.GetInstance();
        lcm.OpenMenu();
    }

    public void Noclip()
    {
        GameObject.Find("Player").GetComponent<InteractiveObject>().noclip=!GameObject.Find("Player").GetComponent<InteractiveObject>().noclip;
    }
}
