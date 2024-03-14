using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadSystem
{
    static string levelsCompletedPath = Application.dataPath + "/levelscompleted.dat";

    public static void Save(int levesCompleted)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(levelsCompletedPath);

        bf.Serialize(file, levesCompleted);
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
}
