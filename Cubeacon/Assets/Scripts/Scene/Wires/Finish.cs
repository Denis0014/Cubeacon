using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : Switch
{
    public float timer1;
    private bool alreadyFinished;
    private AudioSource audioSource;

    public void FinishLevel()
    {
        SaveLoadSystem.SaveThisLevel();
        alreadyFinished = true;

        Debug.Log("Win");
        Debug.Log(SaveLoadSystem.LoadLevelsCompleted());

        LevelCompleteManager lcm = LevelCompleteManager.GetInstance();
        lcm.OpenMenu();
    }

    protected override void Start()
    {
        base.Start();
        timer1 = 1f;
        audioSource = GetComponent<AudioSource>();
        activated_color = new Color32(255, 255, 255, 255);
        deactivated_color = new Color32(255, 255, 255, 255);
    }

    protected override void Update()
    {
        if (activated && !alreadyFinished && timer1 > 0)
        {
            PlayFinishSound();
            timer1 -= Time.deltaTime;
            if (timer1 <= 0)
            {
                FinishLevel();
                timer1 = 1f;
            }
        }
        base.Update();
    }

    private void PlayFinishSound()
    {
        if (timer1 == 1f)
            audioSource.Play();
    }

    protected override void Update_pos()
    {
    }
}
