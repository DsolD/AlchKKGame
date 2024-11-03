using UnityEngine;

public class SaveLoadManager : MonoBehaviour // надо добавить что при заходе сцены в меню оно сохранялось
{
    public DataManagerSave dataManager; // Ссылка на DataManagerSave

    void Start()
    {
        // Получаем экземпляр DataManagerSave
        dataManager = Object.FindFirstObjectByType<DataManagerSave>();

        // Загружаем данные при запуске игры
        if (dataManager != null)
        {
            dataManager.LoadData();
        }
    }

    void OnApplicationQuit()
    {
        // Сохраняем данные при выходе из игры
        if (dataManager != null)
        {
            dataManager.SaveData();
        }
    }
}

