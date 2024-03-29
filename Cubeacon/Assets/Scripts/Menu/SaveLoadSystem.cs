using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoadSystem
{
    const int LEVEL_SELECT_SCREEN_INDEX = 1;
    static string levelsCompletedPath = Application.dataPath + "/levelscompleted.dat";

    public static void SaveThisLevel()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(levelsCompletedPath);

        int levelsCompleted = SceneManager.GetActiveScene().buildIndex;
        bf.Serialize(file, levelsCompleted);
        file.Close();
    }

    public static int LoadLevelsCompleted()
    {
        if (File.Exists(levelsCompletedPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(levelsCompletedPath);
            return (int)bf.Deserialize(file);
        }

        return 0;
    }

    public static void LoadLevelSelectScreen()
    {
        SceneManager.LoadScene(LEVEL_SELECT_SCREEN_INDEX);
    }
}
