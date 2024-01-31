using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenu;
    private bool PauseIsActive;

    [SerializeField] public GameObject HelpMenu;
    private bool HelpIsPlaying;

    [SerializeField] public GameObject SettingsMenu;

    [SerializeField] public GameObject Player;
    movePlayer MPScript;

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

    private void Start()
    {
        PauseIsActive = false;
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false); 
        HelpMenu.SetActive(false);

        HintCounter = 0;
       
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        MPScript = Player.GetComponent<movePlayer>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseIsActive)
            {
                EnterPauseMode();
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
                    ExitPauseMode();
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
        ExitPauseMode();
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

    private void EnterPauseMode()
    {
        PauseIsActive = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        MPScript.PauseMenu = true;
    }

    private void ExitPauseMode()
    {   
        PauseIsActive = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        MPScript.PauseMenu = false;
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