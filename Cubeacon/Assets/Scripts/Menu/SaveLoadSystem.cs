using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoadSystem
{
    static string levelsCompletedPath = Application.dataPath + "/levelscompleted.dat";

    public static void SaveThisLevel()
    {
        int levelNumber = GetLevelNumber();
        if (LevelShouldBeSaved(levelNumber))
            Save(levelNumber);
    }

    public static int LoadLevelsCompleted()
    {
        if (File.Exists(levelsCompletedPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(levelsCompletedPath);

            int res = (int)bf.Deserialize(file);
            file.Close();

            return res;
        }
        return 0;
    }

    private static int GetLevelNumber()
    {
        string levelName = SceneManager.GetActiveScene().name;
        return int.Parse(levelName);
    }

    private static bool LevelShouldBeSaved(int levelNumber)
    {
        int completedLevels = LoadLevelsCompleted();
        return levelNumber > completedLevels;
    }

    private static void Save(int levelNumber)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(levelsCompletedPath);
        
        bf.Serialize(file, levelNumber);
        file.Close();
    }
}
