using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class PersistentData : MonoBehaviour
{
    // Start is called before the first frame update

    static public string pName;
    static public int pScore;

    public static PersistentData Instance;
    public static PersistentData.HighScore HSInstance;

    void Start()
    {
        pName = "DefaultName";

        Instance = this;
        DontDestroyOnLoad(gameObject);

        HSInstance = new HighScore();

        string path = Application.persistentDataPath + "highscore.save";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistentData.HSInstance = JsonUtility.FromJson<HighScore>(json);
        } 
        else
        {
            PersistentData.HSInstance.name = "Pidor";
            PersistentData.HSInstance.score = 0;
        }
    }

    public static void RecordNewHighScore(int newRecord, string newName)
    {
        HSInstance.score = newRecord;
        HSInstance.name = newName;

        string path = Application.persistentDataPath + "highscore.save";
        string json = JsonUtility.ToJson(HSInstance);

        Debug.Log(path + " " + json);
        File.WriteAllText(path, json);
    }

    [Serializable]
    public class HighScore
    {
        public int score;
        public string name;
    }
}
