using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance; // Singleton pattern

    // Добавили поля для хранения информации
    public Dictionary<string, int> Ingredients = new Dictionary<string, int>();
    public Dictionary<string, int> Potions = new Dictionary<string, int>();
    public int Coin;

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/save_data.json";
            Load(); // Загружаем данные при запуске
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(this);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("Data saved to: " + savePath);
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(jsonData, this);
            Debug.Log("Data loaded from: " + savePath);
        }
        else
        {
            // Инициализируем значения по умолчанию, если файл не существует
            Ingredients.Add("wood", 5);
            Ingredients.Add("stone", 10);
            Ingredients.Add("iron", 15);
            Potions.Add("healing", 20);
            Potions.Add("strength", 30);
            Potions.Add("speed", 40);
            Coin = 100;
        }
    }
}
