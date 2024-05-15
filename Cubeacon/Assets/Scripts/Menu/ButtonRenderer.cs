using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRenderer : MonoBehaviour
{
    [SerializeField] public GameObject UnlockedImage;

    [SerializeField] public GameObject LockedImage;

    public int number;
    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        int completedLevels = SaveLoadSystem.LoadLevelsCompleted();

        if (completedLevels >= number - 1)
        {
            locked = false;
            UnlockedImage.SetActive(true);
            LockedImage.SetActive(false);
        }

        else
        {
            locked = true;
            UnlockedImage.SetActive(false);
            LockedImage.SetActive(true);
        }
    }

    public void OpenScene()
    {
        if (!locked)
            SceneManager.LoadScene(number.ToString());
    }
}
