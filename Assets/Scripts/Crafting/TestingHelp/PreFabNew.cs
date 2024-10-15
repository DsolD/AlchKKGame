using UnityEngine;
using UnityEngine.UI;

public class PreFabNew : MonoBehaviour
{
    public Button HelpButton;
    public GameObject[] AllPrefabs; // Массив префабов, которые нужно показывать
    public Transform parentTransform; // Трансформ родительского объекта для созданных изображений

    private GameObject[] prefabInstances; // Массив для хранения созданных экземпляров префабов

    public Vector2 canvasSize; // Размер Canvas
    public Vector2 prefabSize = new Vector2(100, 150); // Размер префабов

    private void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);

        // Инициализируем массив prefabInstances
        prefabInstances = new GameObject[AllPrefabs.Length];
        for (int i = 0; i < AllPrefabs.Length; i++)
        {
            prefabInstances[i] = null;
        }
    }

    void Recoveries()
    {
        // Проверяем, не уничтожены ли префабы
        for (int i = 0; i < AllPrefabs.Length; i++)
        {
            if (prefabInstances[i] == null)
            {
                // Если префаб уничтожен, создаем его заново
                prefabInstances[i] = CreatePrefabInstance(AllPrefabs[i]);
            }
            else
            {
                // Если префаб не уничтожен, просто показываем его
                prefabInstances[i].SetActive(true);
            }
        }
    }

    // Функция для создания нового экземпляра префаба
    private GameObject CreatePrefabInstance(GameObject prefab)
    {
        // Генерируем случайную позицию на Canvas
        Vector2 randomPosition = new Vector2(
            Random.Range(-canvasSize.x / 2 + prefabSize.x / 2, canvasSize.x / 2 - prefabSize.x / 2),
            Random.Range(-canvasSize.y / 2 + prefabSize.y / 2, canvasSize.y / 2 - prefabSize.y / 2)
        );

        // Создаем новый экземпляр префаба
        GameObject newPrefabInstance = Instantiate(prefab, parentTransform);
        newPrefabInstance.transform.localPosition = randomPosition; // Устанавливаем случайную позицию

        // Устанавливаем размер префаба (если нужно)
        RectTransform rectTransform = newPrefabInstance.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = prefabSize;
        }

        return newPrefabInstance;
    }
}

