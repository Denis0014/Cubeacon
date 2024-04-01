using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class PauseManager : InGameMenuManager
{
    [SerializeField] public GameObject PauseMenu;

    [SerializeField] public GameObject HelpMenu;
    private bool HelpIsPlaying;

    [SerializeField] public GameObject SettingsMenu;

    [SerializeField] public GameObject HintButton;
    private int HintCounter;
    private Story CurrentHint;

    [SerializeField] TextAsset inkJSON;

    [SerializeField] TextMeshProUGUI HelpText;

    private static PauseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static PauseManager GetInstance()
    {
        return instance;
    }

    private new void Start()
    {
        base.Start();
        
        SettingsMenu.SetActive(false); 
        HelpMenu.SetActive(false);

        HintCounter = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseIsActive)
            {
                OpenMenu();
            }
            else
            {
                if (HelpMenu.activeSelf)
                {
                    HelpMenu.SetActive(false);
                    PauseMenu.SetActive(true);
                }
                else if (SettingsMenu.activeSelf)
                {
                    SettingsMenu.SetActive(false);
                    PauseMenu.SetActive(true);
                }
                else
                {
                    CloseMenu();
                }
            }
        }

        if (!HelpIsPlaying)
        {
            return;
        }
        if (HintCounter == 3)
        {
            HintButton.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ContinueHint();
            HintCounter += 1;
        }
    }

    public void ReturnPressed()
    {
        CloseMenu();
    }

    public void ButtonHelpPressed()
    {
        if (HintCounter == 0)
        {
            PauseManager.GetInstance().EnterHelpMode(inkJSON);
            HintCounter += 1;
        }
    }

    public void ButtonHintPressed()
    {
        ContinueHint();
        HintCounter += 1;
    }

    private void ContinueHint()
    {
        if (CurrentHint.canContinue)
        {
            HelpText.text = CurrentHint.Continue();
        }
        else
        {
            ExitHelpMode();
        }
    }

    public void EnterHelpMode(TextAsset inkJSON)
    {
        CurrentHint = new Story(inkJSON.text);
        HelpIsPlaying = true;
        HelpMenu.SetActive(true);

        ContinueHint();
    }

    private void ExitHelpMode()
    {
        HelpIsPlaying = false;
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}