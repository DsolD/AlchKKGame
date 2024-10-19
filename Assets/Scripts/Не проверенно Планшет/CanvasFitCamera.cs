using UnityEngine;
using UnityEngine.UI;

public class CanvasFitCamera : MonoBehaviour
{
    public Canvas targetCanvas; // ������ �� Canvas, ������� ����� ����������
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
        // ��������� �������� ������
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        // ���������� �������� Canvas
        float canvasWidth = screenWidth;
        float canvasHeight = screenHeight;

        // ��������� �������� Canvas
        canvasRect.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        // ������������ Canvas �� ������ ������
        canvasRect.anchoredPosition = new Vector2(0, 0);
    }

}

