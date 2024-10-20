using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    // Ссылки на объекты
    public Camera mainCamera;

    public Canvas CraftingCanvas;
    public Canvas StupaCanvas;
    public Canvas SoldCanvas;
    public Canvas ExitCanvas;

    // Кнопки для перехода между Canvas
    public Button CraftingButton;
    public Button StupaButton;
    public Button CraftingSoldButton; // Кнопка Sold на CraftingCanvas
    public Button ExitSoldButton; // Кнопка Sold на ExitCanvas 
    public Button ExitButton;

    public float moveSpeed = 5f; // Скорость перемещения камеры
    public float zoomSpeed = 4f; // Скорость приближения камеры - УВЕЛИЧЕННАЯ скорость
    public float initialOrthographicSize = 5f; // Начальный ортографический размер камеры
    public float targetOrthographicSize = 8f; // Целевой ортографический размер камеры при увеличении (zoom out)

    public float zoomInSpeed = 2f; // Скорость уменьшения при ZoomIn (медленнее)

    private bool isZooming = false; // Флаг, указывающий, происходит ли увеличение камеры


    private void Awake()
    {

        HideCraftingCanvas();
        HideExitCanvas();
      //  HideSoldCanvas(); временное решения пока не нету запомиинание твоей сцены
        HideStupaCanvas();
        //CraftingCanvas.GetComponent<CanvasGroup>().interactable = false; // Предотвращает взаимодействие
    }


    private void Start()
    {
        // Добавление обработчиков кликов
        CraftingButton.onClick.AddListener(MoveToCrafting);
        StupaButton.onClick.AddListener(MoveToStupa);
        CraftingSoldButton.onClick.AddListener(MoveToSoldFromCrafting);
        ExitSoldButton.onClick.AddListener(MoveToSoldFromExit);
        ExitButton.onClick.AddListener(MoveToExit);

        // Увеличиваем размер камеры при запуске игры
        mainCamera.orthographicSize = initialOrthographicSize; // Начальный размер 5
    }

    private void ShowCraftingCanvas()
    {

        CraftingCanvas.GetComponent<CanvasGroup>().alpha = 1; // Установите альфа-канал в 0 для полной прозрачности
        CraftingCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true; // Предотвращает нажатия

    }

    private void ShowStupaCanvas()
    {

        StupaCanvas.GetComponent<CanvasGroup>().alpha = 1; // Установите альфа-канал в 0 для полной прозрачности
        StupaCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true; // Предотвращает нажатия

    }

    private void ShowExitCanvas()
    {

        ExitCanvas.GetComponent<CanvasGroup>().alpha = 1; // Установите альфа-канал в 0 для полной прозрачности
        ExitCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true; // Предотвращает нажатия

    }
    private void ShowSoldCanvas()
    {

        SoldCanvas.GetComponent<CanvasGroup>().alpha = 1; // Установите альфа-канал в 0 для полной прозрачности
        SoldCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true; // Предотвращает нажатия

    }

    /// ////////////////////////////////////////////////////////////////////////
    private void HideCraftingCanvas()
    {

        CraftingCanvas.GetComponent<CanvasGroup>().alpha = 0.7f; // Установите альфа-канал в 0.7f для полной прозрачности
        CraftingCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false; // Предотвращает нажатия

    }

    private void HideStupaCanvas()
    {

        StupaCanvas.GetComponent<CanvasGroup>().alpha = 0.7f; // Установите альфа-канал в 0.7f для полной прозрачности
        StupaCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false; // Предотвращает нажатия

    }

    private void HideExitCanvas()
    {

        ExitCanvas.GetComponent<CanvasGroup>().alpha = 0.7f; // Установите альфа-канал в 0.7f для полной прозрачности
        ExitCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false; // Предотвращает нажатия

    }
    private void HideSoldCanvas()
    {

        SoldCanvas.GetComponent<CanvasGroup>().alpha = 0.7f; // Установите альфа-канал в 0,7f для полной прозрачности
        SoldCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false; // Предотвращает нажатия

    }


    public void MoveToCrafting()
    {
        ZoomInOut(); // Вызываем ZoomInOut для всех кнопок
        StartCoroutine(MoveCamera(CraftingCanvas.transform.position));

        ShowCraftingCanvas();
        HideSoldCanvas();
    }

    public void MoveToStupa()
    {
        ZoomInOut(); // Вызываем ZoomInOut для всех кнопок
        StartCoroutine(MoveCamera(StupaCanvas.transform.position));

        ShowStupaCanvas();
        HideSoldCanvas ();

    }

    public void MoveToSoldFromCrafting()
    {
        ZoomInOut(); // Вызываем ZoomInOut для всех кнопок
        StartCoroutine(MoveCamera(SoldCanvas.transform.position));

        ShowSoldCanvas();
        HideCraftingCanvas();

    }

    public void MoveToSoldFromExit()
    {
        ZoomInOut(); // Вызываем ZoomInOut для всех кнопок
        StartCoroutine(MoveCamera(SoldCanvas.transform.position));

        ShowSoldCanvas();
        HideExitCanvas();

    }

    public void MoveToExit()
    {
        ZoomInOut(); // Вызываем ZoomInOut для всех кнопок
        StartCoroutine(MoveCamera(ExitCanvas.transform.position));

        HideSoldCanvas();
        ShowExitCanvas();

    }

    private IEnumerator MoveCamera(Vector2 targetPosition)
    {
        // Получаем начальную позицию камеры
        Vector2 currentPosition = mainCamera.transform.position;

        // Перемещаем камеру
        while (Vector2.Distance(currentPosition, targetPosition) > 0f)
        {
            currentPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
            mainCamera.transform.position = currentPosition;
            yield return null;
        }
    }

    private void ZoomInOut()
    {
        if (!isZooming)
        {
            StartCoroutine(ZoomOut2());
        }
    }
    private IEnumerator ZoomOut2() // Добавленный метод ZoomOut с паузами и уменьшениями
    {

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetOrthographicSize, elapsedTime / 50f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isZooming = true;
        yield return new WaitForSeconds(3.52f); // Пауза для плавного перехода ПРИБЛЕЖЕНИЯ КАМЕРЫ  К КАНВАСУ
        StartCoroutine(ZoomIn()); // Запускаем ZoomIn после паузы
        isZooming = false;

        // Добавляем паузу перед уменьшением
        yield return new WaitForSeconds(3.52f); // Пауза для плавного перехода ПРИБЛЕЖЕНИЯ КАМЕРЫ  К КАНВАСУ

        // Уменьшаем размер камеры за 0.2 секунды
        elapsedTime = 0f;
        while (elapsedTime < 0.3f)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, initialOrthographicSize, elapsedTime / 0.3f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ZoomIn()
    {
        while (mainCamera.orthographicSize > initialOrthographicSize)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, initialOrthographicSize, zoomInSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // Обновление в каждом кадре
    private void Update()
    {
        // Ничего не делаем, размер камеры управляется MoveCameraTo и ZoomIn
    }

}
