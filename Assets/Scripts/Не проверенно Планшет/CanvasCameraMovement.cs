using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CanvasCameraMovement : MonoBehaviour
{
    public Camera mainCamera; // Ссылка на вашу главную камеру
    public Canvas sellerCanvas; // Canvas для продавца
    public Canvas craftingCanvas; // Canvas для крафта
    public Canvas exitCanvas; // Canvas для выхода
    public Button sellerButton; // Кнопка для перехода к продавцу
    public Button craftingButton; // Кнопка для перехода к крафту
    public Button exitButton; // Кнопка для перехода к выходу

    public float moveSpeed = 5f; // Скорость движения камеры
    public float zoomSpeed = 5f; // Скорость приближения/отдаления камеры
    public float zoomDistance = 5f; // Расстояние для приближения/отдаления
    public float initialDistance = 10f; // Начальное расстояние от камеры

    private Vector2 initialCameraPosition; // Хранит начальную позицию камеры

    void Start()
    {
        // Сохраняем начальную позицию камеры
        initialCameraPosition = mainCamera.transform.position;

        // Устанавливаем начальное расстояние
        mainCamera.transform.position = initialCameraPosition + new Vector2(0, initialDistance);

        // Назначаем обработчики кликов для кнопок
        sellerButton.onClick.AddListener(MoveToSellerCanvas);
        craftingButton.onClick.AddListener(MoveToCraftingCanvas);
        exitButton.onClick.AddListener(MoveToExitCanvas);
    }

    // Перемещаем камеру к канвасу продавца
    private void MoveToSellerCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(sellerCanvas));
    }

    // Перемещаем камеру к канвасу крафта
    private void MoveToCraftingCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(craftingCanvas));
    }

    // Перемещаем камеру к канвасу выхода
    private void MoveToExitCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(exitCanvas));
    }

    // Корутина для перемещения камеры к указанному канвасу
    private IEnumerator MoveToCanvasCoroutine(Canvas targetCanvas)
    {
        // Отдаляем камеру
        StartCoroutine(ZoomOut());

        // Получаем позицию целевого канваса
        Vector2 targetPosition = targetCanvas.transform.position;

        // Плавное перемещение камеры
        while (Vector2.Distance(mainCamera.transform.position, targetPosition) > 0.1f)
        {
            mainCamera.transform.position = Vector2.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        // Приближаем камеру
        StartCoroutine(ZoomIn());
    }

    // Корутина для отдаления камеры
    private IEnumerator ZoomOut()
    {
        float initialOrthographicSize = mainCamera.orthographicSize;

        while (mainCamera.orthographicSize < zoomDistance)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
    }

    // Корутина для приближения камеры
    private IEnumerator ZoomIn()
    {
        while (mainCamera.orthographicSize > initialDistance)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, initialDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
    }
}
