using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class LevelCompleteManager : MonoBehaviour
{
    [SerializeField] public GameObject LevelCompleteMenu;

    [SerializeField] TextAsset inkJSON;

    [SerializeField] TextMeshProUGUI HelpText;

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

    private void Start()
    {
        LevelCompleteMenu.SetActive(false);
    }

    public void EnterPauseMode()
    {
        LevelCompleteMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Levels");
    }
}
