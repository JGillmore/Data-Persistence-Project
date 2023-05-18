using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public TextMeshProUGUI highScoreDisplay;

    public string playerName;
    public int playerScore;
    public string highName;
    public int highScore;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
        if (DataManager.Instance.highScore > 0)
        {
            highScoreDisplay.text = highName + " has a High Score of " + highScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string highName = DataManager.Instance.highName;
        public int highScore = DataManager.Instance.highScore;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highName = DataManager.Instance.highName;
        data.highScore = DataManager.Instance.highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highScoreData.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/highScoreData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            DataManager.Instance.highName = data.highName;
            DataManager.Instance.highScore = data.highScore;
        }
    }
}
