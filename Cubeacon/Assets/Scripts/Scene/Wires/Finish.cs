using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : Switch
{
    private bool alreadyFinished;
    public float timer1;

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
        timer1 = 1f;
        activated_color = new Color32(255, 255, 255, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
    }

    protected override void Update()
    {
        if (activated && !alreadyFinished && timer1 > 0)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                FinishLevel();
                timer1 = 1f;
            }
        }
        base.Update();
    }

    protected override void Update_pos()
    {
    }
}
