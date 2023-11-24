using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject HelpMenu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject Player;
    movePlayer MPScript;

    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
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
    }
    public void ExitPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
