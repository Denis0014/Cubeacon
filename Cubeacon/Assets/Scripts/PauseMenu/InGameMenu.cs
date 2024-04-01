using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;

public class InGameMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject Menu;

    [SerializeField] public GameObject Player;
    movePlayer MPScript;

    protected bool PauseIsActive;

    protected void Start()
    {
        Menu.SetActive(false);
        PauseIsActive = false;
        Player = GameObject.Find("Player");
        MPScript = Player.GetComponent<movePlayer>();
    }

    public void OpenMenu()
    {
        PauseIsActive = true;
        Menu.SetActive(true);
        Time.timeScale = 0.0f;
        MPScript.PauseMenu = true;
    }

    protected void CloseMenu()
    {
        PauseIsActive = false;
        Menu.SetActive(false);
        Time.timeScale = 1.0f;
        MPScript.PauseMenu = false;
    }
}