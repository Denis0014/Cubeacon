using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class LevelCompleteManager : InGameMenuManager
{
    private static LevelCompleteManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Level Complete Manager in the scene");
        }
        instance = this;
    }

    public static LevelCompleteManager GetInstance()
    {
        return instance;
    }

    public void NextLevelPressed()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene = (int.Parse(currentScene) + 1).ToString();
        SceneManager.LoadScene(nextScene);
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Levels");
    }
}
