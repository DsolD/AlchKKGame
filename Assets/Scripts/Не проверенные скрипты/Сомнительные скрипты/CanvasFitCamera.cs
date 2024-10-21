using UnityEngine;
using UnityEngine.UI;

public class CanvasFitCamera : MonoBehaviour
{
    public Canvas targetCanvas; // Ссылка на Canvas, который нужно подстроить
    private RectTransform canvasRect;

    void Start()
    {
        // Получение RectTransform Canvas
        canvasRect = targetCanvas.GetComponent<RectTransform>();
        // Вызываем функцию для начальной настройки
        UpdateCanvasSize();
    }

    void Update()
    {
        // Проверка, изменилось ли разрешение
        if (Screen.width != canvasRect.rect.width || Screen.height != canvasRect.rect.height)
        {
            // Обновляем размер Canvas
            UpdateCanvasSize();
        }
    }

    void UpdateCanvasSize()
    {
        // Получение размеров экрана
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        // Вычисление размеров Canvas
        float canvasWidth = screenWidth;
        float canvasHeight = screenHeight;

        // Установка размеров Canvas
        canvasRect.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        // Выравнивание Canvas по центру экрана
        canvasRect.anchoredPosition = new Vector2(0, 0);
    }

}

