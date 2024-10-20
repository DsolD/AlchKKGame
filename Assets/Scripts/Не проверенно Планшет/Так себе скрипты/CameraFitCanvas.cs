using UnityEngine;

public class CameraFitCanvas : MonoBehaviour
{
    public Canvas targetCanvas; // Ссылка на Canvas, к которому нужно подстроить камеру

    private void Start()
    {
        // Получение размера Canvas
        RectTransform canvasRect = targetCanvas.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;

        // Получение компонента камеры
        Camera camera = GetComponent<Camera>();

        // Настройка размера и положения камеры
        camera.orthographicSize = canvasSize.y / 2f; // Вычисляем ортографический размер камеры
        transform.position = new Vector3(canvasRect.position.x, canvasRect.position.y, transform.position.z); // Выравниваем центр камеры с центром Canvas
    }
}

