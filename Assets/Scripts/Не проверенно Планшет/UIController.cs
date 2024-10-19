using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    // Ссылки на объекты
    public Camera mainCamera;

    public Canvas CraftingCanvas;
    public Canvas StupaCanvas;
    public Canvas SoldCanvas; // Canvas для отображения Sold
    public Canvas ExitCanvas; // Canvas для отображения Exit

    // Кнопки для перехода между Canvas
    public Button CraftingButton; // Кнопка для перехода на CraftingCanvas
    public Button StupaButton; // Кнопка для перехода на StupaCanvas
    public Button Craft_SoldButton; // Кнопка для перехода на SoldCanvas
    public Button Exit_SoldButton; // Кнопка для перехода на SoldCanvas
    public Button ExitButton; // Кнопка для перехода на ExitCanvas

    public Vector2 targetPosition; // Целевая позиция для перемещения
    public float moveSpeed = 5f; // Скорость перемещения

    private Vector2 currentPosition; // Текущая позиция
    private bool isMoving = false; // Флаг для отслеживания перемещения

    // Метод для перемещения
    public void MoveTo(Vector2 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    // Метод для отображения SoldCanvas
    public void ShowSoldCanvas()
    {
        SoldCanvas.gameObject.SetActive(true);
    }

    // Метод для отображения ExitCanvas
    public void ShowExitCanvas()
    {
        ExitCanvas.gameObject.SetActive(true);
    }

    // Метод для перехода на CraftingCanvas
    public void GoToCrafting()
    {
        MoveTo(CraftingCanvas.transform.position);
    }

    // Метод для перехода на StupaCanvas
    public void GoToStupa()
    {
        MoveTo(StupaCanvas.transform.position);
    }

    // Метод для перехода на SoldCanvas
    public void CraftGoToSold()
    {
        MoveTo(SoldCanvas.transform.position);
    }

    public void ExitGoToSold()
    {
        MoveTo(SoldCanvas.transform.position);
    }

    // Метод для перехода на ExitCanvas
    public void GoToExit()
    {
        MoveTo(ExitCanvas.transform.position);
    }

    // Обновление положения Canvas
    private void Update()
    {
        // Перемещение Canvas если isMoving = true
        if (isMoving)
        {
            // Получение текущего положения
            currentPosition = CraftingCanvas.transform.position;

            // Рассчет расстояния до целевой точки
            float distance = Vector2.Distance(currentPosition, targetPosition);

            // Перемещение с помощью Vector2.MoveTowards
            CraftingCanvas.transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

            // Проверка достижения целевой точки
            if (distance <= 0.1f)
            {
                isMoving = false;
            }
        }
    }

    // Метод для плавного перехода между Canvas-ами
    private IEnumerator FadeCanvas(CanvasGroup canvasGroup, float targetAlpha, float speed)
    {
        while (Mathf.Abs(canvasGroup.alpha - targetAlpha) > 0.01f)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }

    // Настройка кнопок при запуске
    private void Start()
    {

        // Добавление обработчиков кликов
        CraftingButton.onClick.AddListener(GoToCrafting);
        StupaButton.onClick.AddListener(GoToStupa);
        Exit_SoldButton.onClick.AddListener(ExitGoToSold);
        Craft_SoldButton.onClick.AddListener(CraftGoToSold);
        ExitButton.onClick.AddListener(GoToExit);

    }

}
