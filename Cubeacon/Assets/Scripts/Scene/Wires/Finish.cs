using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : WiringSys
{
    private bool alreadyFinished;

    public void FinishLevel()
    {
        SaveLoadSystem.SaveThisLevel();
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
            alreadyFinished = true;
            Debug.Log("Win");
            Debug.Log(SaveLoadSystem.LoadLevelsCompleted());
        }
        base.Update();
    }

    protected override void Update_pos()
    {
    }
}
