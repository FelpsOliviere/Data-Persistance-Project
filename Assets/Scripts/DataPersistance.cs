using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance Instance;
    public MenuUIHandler menu;
    public string newPlayer;
    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        menu = GameObject.Find("Canvas").GetComponent<MenuUIHandler>();
        LoadInformations();
    }

    private void Update()
    {
        newPlayer = menu.inputField.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveInformations()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInformations()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
    }
}
