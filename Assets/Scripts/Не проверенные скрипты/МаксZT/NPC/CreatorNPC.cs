using UnityEngine;
using UnityEngine.UI;

public class CreatorNPC : MonoBehaviour
{
    // Префаб объекта, который нужно создавать
    public GameObject prefab;

    // Канвас, на котором будет создаваться объект
    public Canvas canvas;

    public Button creatornpcbutton;

    public void Start()
    {
        creatornpcbutton.onClick.AddListener(CreateObject);
    }

    // Метод для создания объекта
    public void CreateObject()
    {
        // Создание экземпляра префаба
        GameObject newObject = Instantiate(prefab);

        // Получение RectTransform нового объекта
        RectTransform rectTransform = newObject.GetComponent<RectTransform>();

        // Установка родителя объекта как канвас
        rectTransform.SetParent(canvas.transform, false);

        // Центрирование объекта на канвасе
        rectTransform.anchorMin = new Vector2(0.8f, 0.6f);
        rectTransform.anchorMax = new Vector2(0.8f, 0.6f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;

        // Дополнительные настройки (необязательно)
        // Например, можно установить размер объекта или поворот
    }
}

