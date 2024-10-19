using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    // ������ �� �������
    public Camera mainCamera;

    public Canvas CraftingCanvas;
    public Canvas StupaCanvas;
    public Canvas SoldCanvas; // Canvas ��� ����������� Sold
    public Canvas ExitCanvas; // Canvas ��� ����������� Exit

    // ������ ��� �������� ����� Canvas
    public Button CraftingButton; // ������ ��� �������� �� CraftingCanvas
    public Button StupaButton; // ������ ��� �������� �� StupaCanvas
    public Button Craft_SoldButton; // ������ ��� �������� �� SoldCanvas
    public Button Exit_SoldButton; // ������ ��� �������� �� SoldCanvas
    public Button ExitButton; // ������ ��� �������� �� ExitCanvas

    public Vector2 targetPosition; // ������� ������� ��� �����������
    public float moveSpeed = 5f; // �������� �����������

    private Vector2 currentPosition; // ������� �������
    private bool isMoving = false; // ���� ��� ������������ �����������

    // ����� ��� �����������
    public void MoveTo(Vector2 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    // ����� ��� ����������� SoldCanvas
    public void ShowSoldCanvas()
    {
        SoldCanvas.gameObject.SetActive(true);
    }

    // ����� ��� ����������� ExitCanvas
    public void ShowExitCanvas()
    {
        ExitCanvas.gameObject.SetActive(true);
    }

    // ����� ��� �������� �� CraftingCanvas
    public void GoToCrafting()
    {
        MoveTo(CraftingCanvas.transform.position);
    }

    // ����� ��� �������� �� StupaCanvas
    public void GoToStupa()
    {
        MoveTo(StupaCanvas.transform.position);
    }

    // ����� ��� �������� �� SoldCanvas
    public void CraftGoToSold()
    {
        MoveTo(SoldCanvas.transform.position);
    }

    public void ExitGoToSold()
    {
        MoveTo(SoldCanvas.transform.position);
    }

    // ����� ��� �������� �� ExitCanvas
    public void GoToExit()
    {
        MoveTo(ExitCanvas.transform.position);
    }

    // ���������� ��������� Canvas
    private void Update()
    {
        // ����������� Canvas ���� isMoving = true
        if (isMoving)
        {
            // ��������� �������� ���������
            currentPosition = CraftingCanvas.transform.position;

            // ������� ���������� �� ������� �����
            float distance = Vector2.Distance(currentPosition, targetPosition);

            // ����������� � ������� Vector2.MoveTowards
            CraftingCanvas.transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

            // �������� ���������� ������� �����
            if (distance <= 0.1f)
            {
                isMoving = false;
            }
        }
    }

    // ����� ��� �������� �������� ����� Canvas-���
    private IEnumerator FadeCanvas(CanvasGroup canvasGroup, float targetAlpha, float speed)
    {
        while (Mathf.Abs(canvasGroup.alpha - targetAlpha) > 0.01f)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }

    // ��������� ������ ��� �������
    private void Start()
    {

        // ���������� ������������ ������
        CraftingButton.onClick.AddListener(GoToCrafting);
        StupaButton.onClick.AddListener(GoToStupa);
        Exit_SoldButton.onClick.AddListener(ExitGoToSold);
        Craft_SoldButton.onClick.AddListener(CraftGoToSold);
        ExitButton.onClick.AddListener(GoToExit);

    }

}
