using UnityEngine;

public class CameraFitCanvas : MonoBehaviour
{
    public Canvas targetCanvas; // ������ �� Canvas, � �������� ����� ���������� ������

    private void Start()
    {
        // ��������� ������� Canvas
        RectTransform canvasRect = targetCanvas.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;

        // ��������� ���������� ������
        Camera camera = GetComponent<Camera>();

        // ��������� ������� � ��������� ������
        camera.orthographicSize = canvasSize.y / 2f; // ��������� ��������������� ������ ������
        transform.position = new Vector3(canvasRect.position.x, canvasRect.position.y, transform.position.z); // ����������� ����� ������ � ������� Canvas
    }
}

