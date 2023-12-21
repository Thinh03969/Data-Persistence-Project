using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance;
    public string PlayerName = null;
    public int p_score = 0;
    public string p_name = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [Serializable]
    public class BestPlay
    {
        public int score;
        public string playerName;
    }

    public void SavePlayer()
    {
        BestPlay bestPlay = new BestPlay();
        bestPlay.score = p_score;
        bestPlay.playerName = p_name;

        string json = JsonUtility.ToJson(bestPlay);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlay bestPlay = JsonUtility.FromJson<BestPlay>(json);

            p_name = bestPlay.playerName;
            p_score = bestPlay.score;
        }
    }
}
