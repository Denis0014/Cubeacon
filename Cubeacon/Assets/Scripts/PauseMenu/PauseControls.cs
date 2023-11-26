using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class PauseControls : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenu;

    [SerializeField] public GameObject HelpMenu;

    [SerializeField] public GameObject SettingsMenu;

    [SerializeField] public GameObject Player;

    [SerializeField] public GameObject HintButton;

    [SerializeField] TextAsset inkJSON;

    [SerializeField] TextMeshProUGUI HelpText;

    private int HintCounter;

    private Story CurrentHint;

    private static PauseControls instance;

    private bool HelpIsPlaying;
    
    movePlayer MPScript;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("AAAAAA");
        }
        instance = this;
    }

    public static PauseControls GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        HintCounter = 0;
        HelpIsPlaying = false;
        HelpMenu.SetActive(false);
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        MPScript = Player.GetComponent<movePlayer>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf == true)
            {
                PauseMenu.SetActive(false);
            }
            else
            {
                PauseMenu.SetActive(true);
            }
            if (HelpMenu.activeSelf == true)
            {
                HelpMenu.SetActive(false);
                PauseMenu.SetActive(true);
            }
            if (SettingsMenu.activeSelf == true)
            {
                SettingsMenu.SetActive(false);
                PauseMenu.SetActive(true);
            }
        }
        if (PauseMenu.activeSelf == true)
        {
            MPScript.PauseMenu = true;
        }
        else if (HelpMenu.activeSelf == true)
        {
            MPScript.PauseMenu = true;

        }
        else if (SettingsMenu.activeSelf == true)
        {
            MPScript.PauseMenu = true;
        }
        else
        {
            MPScript.PauseMenu = false;
        }

        if (!HelpIsPlaying)
        {
            return;
        }
        if (HintCounter == 3)
        {
            HintButton.SetActive(false);
        }
    }

    public void ButtonHelpPressed()
    {
        if (HintCounter == 0)
        {
            PauseControls.GetInstance().EnterHelpMode(inkJSON);
            HintCounter += 1;
        }
    }
    public void ButtonHintPressed()
    {
        ContinueHint();
        HintCounter += 1;
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("Menu");
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
}