using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : WiringSys
{
    private bool alreadyFinished;

    public void FinishLevel()
    {
        SaveLoadSystem.SaveThisLevel();
        alreadyFinished = true;

        Debug.Log("Win");
        Debug.Log(SaveLoadSystem.LoadLevelsCompleted());

        LevelCompleteManager lcm = LevelCompleteManager.GetInstance();
        lcm.EnterPauseMode();
    }

    protected override void Start()
    {
        base.Start();
        activated_color = new Color32(255, 255, 255, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
    }

    protected override void Update()
    {
        if (activated && !alreadyFinished)
        {
            FinishLevel();
        }
        base.Update();
    }

    protected override void Update_pos()
    {
    }
}
