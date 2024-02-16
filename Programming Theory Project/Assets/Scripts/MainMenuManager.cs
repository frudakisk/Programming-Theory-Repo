using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public int highscore;
    public string username;

    public string highscoreName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.highscoreName = highscoreName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
            highscoreName = data.highscoreName;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public int highscore;
        public string highscoreName;
    }
}
