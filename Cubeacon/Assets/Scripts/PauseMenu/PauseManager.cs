using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class PauseManager : InGameMenuManager
{
    [SerializeField] public GameObject MenuPanel;

    [SerializeField] public GameObject HelpMenu;
    private bool HelpIsPlaying;

    [SerializeField] public GameObject SettingsMenu;

    [SerializeField] public GameObject HintButton;
    private int HintCounter;
    private Story CurrentHint;

    [SerializeField] public GameObject ApproveMenu;

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
            if (PauseIsActive && Menu.activeSelf)
            {
                if (HelpMenu.activeSelf)
                {
                    CloseSubMenu(HelpMenu);
                }
                else if (SettingsMenu.activeSelf)
                {
                    CloseSubMenu(SettingsMenu);
                }
                else if (ApproveMenu.activeSelf)
                {
                    CloseSubMenu(ApproveMenu);
                }
                else
                {
                    CloseMenu();
                }
            }
            else if (!PauseIsActive)
            {
                OpenMenu();
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

    private void CloseSubMenu(GameObject subMenu)
    {
        subMenu.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void ReturnPressed()
    {
        CloseMenu();
    }

    public void ButtonHelpPressed()
    {
        HintButton.SetActive(true);
        EnterHelpMode(inkJSON);
        HintCounter = 1;
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