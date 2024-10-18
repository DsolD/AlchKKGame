using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIController : MonoBehaviour
{
    // ������ �� �������
    public Canvas CraftingCanvas;
    public Canvas StupaCanvas;
    public Camera mainCamera;
    public Button grindButton;

    // ���������� ���������
    public bool isStupaActive = false; // private ����� ������ �� ��
    public bool isGrinding = false;// private ����� ������ �� ��

    // ���������� ��� ������� ���������
    private float transitionSpeed = 5f; // �������� ��������
    private CanvasGroup craftingCanvasGroup;
    private CanvasGroup stupaCanvasGroup;

    private void Awake()
    {
        // ��������� CanvasGroup ��� ������� ���������
        craftingCanvasGroup = CraftingCanvas.GetComponent<CanvasGroup>();
        stupaCanvasGroup = StupaCanvas.GetComponent<CanvasGroup>();

        // ����������� ���������
        craftingCanvasGroup.alpha = 1f; // ������ ���������
        stupaCanvasGroup.alpha = 0f; // ������ �����������
    }

    // ������ ��������� UI
    public void BackToCrafting()
    {
        // ������� �������
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 1f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 0f, transitionSpeed));

        // ����������� ���������
        grindButton.gameObject.SetActive(false);
        isStupaActive = false;
        isGrinding = false;
    }

    // ������ ��� ��������� � ����������� �����
    public void ActivateStupa()
    {
        // ������� �������
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 0f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 1f, transitionSpeed));

        isStupaActive = true;
        grindButton.gameObject.SetActive(true);
    }

    public void DeactivateStupa()
    {
        // ������� �������
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 1f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 0f, transitionSpeed));

        isStupaActive = false;
        grindButton.gameObject.SetActive(false);
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
}
