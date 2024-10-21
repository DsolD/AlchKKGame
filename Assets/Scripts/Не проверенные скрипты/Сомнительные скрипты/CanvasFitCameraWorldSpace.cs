using UnityEngine;
using UnityEngine.UI;

public class CanvasFitCameraWorldSpace : MonoBehaviour
{
    public Canvas targetCanvas; // Ссылка на Canvas, который нужно подстроить
    public Camera mainCamera; // Ссылка на основную камеру
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
        // Получение размеров экрана в пикселях
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Получение размеров экрана в единицах мира
        Vector2 screenWorldSize = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        // Вычисление размеров Canvas в единицах мира
        float canvasWidth = screenWorldSize.x;
        float canvasHeight = screenWorldSize.y;

        // Установка размеров Canvas
        canvasRect.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        // Выравнивание Canvas по центру экрана
        canvasRect.anchoredPosition = new Vector2(0, 0);
    }
}

