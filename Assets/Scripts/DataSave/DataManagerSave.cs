using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SaveData
{
    public int _Coin;
    public Dictionary<string, Ingredient> _ingredients;
    public Dictionary<string, Potion> _potions;
}

public class DataManagerSave : MonoBehaviour
{

    private string saveFilePath;

    void Awake()
    {
        // Получаем путь к папке сохранения в Awake()
        saveFilePath = Application.persistentDataPath + "/save.dat";
    }

    public void SaveData()
    {
        // Создаем новый объект BinaryFormatter для сериализации
        BinaryFormatter formatter = new BinaryFormatter();

        // Создаем поток для записи данных в файл
        FileStream fileStream = File.Create(saveFilePath);

        // Создаем экземпляр SaveData для хранения всех данных
        SaveData dataToSave = new SaveData();

        // Копируем данные из словарей Ingredients и Potions в SaveData
        dataToSave._Coin = Information.Coin;
        dataToSave._ingredients = Information.Ingredients;
        dataToSave._potions = Information.Potions;

        // Сериализуем данные в поток файла
        formatter.Serialize(fileStream, dataToSave);
        fileStream.Close();
    }

    public void LoadData()
    {
        // Проверяем, существует ли файл сохранения
        if (File.Exists(saveFilePath)) // Используем saveFilePath
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.OpenRead(saveFilePath); // Используем saveFilePath

            // Десериализуем данные из файла
            SaveData loadedData = (SaveData)formatter.Deserialize(fileStream);
            fileStream.Close();

            // Загружаем данные о ингредиентах и зельях
            Information.Ingredients = loadedData._ingredients;
            Information.Potions = loadedData._potions;
            Information.Coin = loadedData._Coin;
        }
    }
}

