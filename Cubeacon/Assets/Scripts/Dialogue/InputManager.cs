using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


//[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    
    private static InputManager instance;

   

    public static InputManager GetInstance()
    {
        return instance;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game") 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    
}
