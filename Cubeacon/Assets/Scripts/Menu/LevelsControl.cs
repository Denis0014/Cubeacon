using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsControl : MonoBehaviour
{
    public string SceneNumber;

    public void OpenScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }

}
