using UnityEngine;
using UnityEngine.UI;

public class CanvasFitCameraWorldSpace : MonoBehaviour
{
    public Canvas targetCanvas; // ������ �� Canvas, ������� ����� ����������
    public Camera mainCamera; // ������ �� �������� ������
    private RectTransform canvasRect;

    void Start()
    {
        // ��������� RectTransform Canvas
        canvasRect = targetCanvas.GetComponent<RectTransform>();
        // �������� ������� ��� ��������� ���������
        UpdateCanvasSize();
    }

    void Update()
    {
        // ��������, ���������� �� ����������
        if (Screen.width != canvasRect.rect.width || Screen.height != canvasRect.rect.height)
        {
            // ��������� ������ Canvas
            UpdateCanvasSize();
        }
    }

    void UpdateCanvasSize()
    {
        // ��������� �������� ������ � ��������
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ��������� �������� ������ � �������� ����
        Vector2 screenWorldSize = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, 0));

        // ���������� �������� Canvas � �������� ����
        float canvasWidth = screenWorldSize.x;
        float canvasHeight = screenWorldSize.y;

        // ��������� �������� Canvas
        canvasRect.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        // ������������ Canvas �� ������ ������
        canvasRect.anchoredPosition = new Vector2(0, 0);
    }
}

