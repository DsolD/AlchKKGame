using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CanvasCameraMovement : MonoBehaviour
{
    public Camera mainCamera; // ������ �� ���� ������� ������
    public Canvas sellerCanvas; // Canvas ��� ��������
    public Canvas craftingCanvas; // Canvas ��� ������
    public Canvas exitCanvas; // Canvas ��� ������
    public Button sellerButton; // ������ ��� �������� � ��������
    public Button craftingButton; // ������ ��� �������� � ������
    public Button exitButton; // ������ ��� �������� � ������

    public float moveSpeed = 5f; // �������� �������� ������
    public float zoomSpeed = 5f; // �������� �����������/��������� ������
    public float zoomDistance = 5f; // ���������� ��� �����������/���������
    public float initialDistance = 10f; // ��������� ���������� �� ������

    private Vector2 initialCameraPosition; // ������ ��������� ������� ������

    void Start()
    {
        // ��������� ��������� ������� ������
        initialCameraPosition = mainCamera.transform.position;

        // ������������� ��������� ����������
        mainCamera.transform.position = initialCameraPosition + new Vector2(0, initialDistance);

        // ��������� ����������� ������ ��� ������
        sellerButton.onClick.AddListener(MoveToSellerCanvas);
        craftingButton.onClick.AddListener(MoveToCraftingCanvas);
        exitButton.onClick.AddListener(MoveToExitCanvas);
    }

    // ���������� ������ � ������� ��������
    private void MoveToSellerCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(sellerCanvas));
    }

    // ���������� ������ � ������� ������
    private void MoveToCraftingCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(craftingCanvas));
    }

    // ���������� ������ � ������� ������
    private void MoveToExitCanvas()
    {
        StartCoroutine(MoveToCanvasCoroutine(exitCanvas));
    }

    // �������� ��� ����������� ������ � ���������� �������
    private IEnumerator MoveToCanvasCoroutine(Canvas targetCanvas)
    {
        // �������� ������
        StartCoroutine(ZoomOut());

        // �������� ������� �������� �������
        Vector2 targetPosition = targetCanvas.transform.position;

        // ������� ����������� ������
        while (Vector2.Distance(mainCamera.transform.position, targetPosition) > 0.1f)
        {
            mainCamera.transform.position = Vector2.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        // ���������� ������
        StartCoroutine(ZoomIn());
    }

    // �������� ��� ��������� ������
    private IEnumerator ZoomOut()
    {
        float initialOrthographicSize = mainCamera.orthographicSize;

        while (mainCamera.orthographicSize < zoomDistance)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
    }

    // �������� ��� ����������� ������
    private IEnumerator ZoomIn()
    {
        while (mainCamera.orthographicSize > initialDistance)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, initialDistance, Time.deltaTime * zoomSpeed);
            yield return null;
        }
    }
}
