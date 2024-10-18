using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIController : MonoBehaviour
{
    // Ссылки на объекты
    public Canvas CraftingCanvas;
    public Canvas StupaCanvas;
    public Camera mainCamera;
    public Button grindButton;

    // Переменные состояния
    public bool isStupaActive = false; // private стоит должно но да
    public bool isGrinding = false;// private стоит должно но да

    // Переменные для плавных переходов
    private float transitionSpeed = 5f; // Скорость перехода
    private CanvasGroup craftingCanvasGroup;
    private CanvasGroup stupaCanvasGroup;

    private void Awake()
    {
        // Получение CanvasGroup для плавных переходов
        craftingCanvasGroup = CraftingCanvas.GetComponent<CanvasGroup>();
        stupaCanvasGroup = StupaCanvas.GetComponent<CanvasGroup>();

        // Изначальное состояние
        craftingCanvasGroup.alpha = 1f; // Полная видимость
        stupaCanvasGroup.alpha = 0f; // Полная невидимость
    }

    // Методы навигации UI
    public void BackToCrafting()
    {
        // Плавный переход
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 1f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 0f, transitionSpeed));

        // Деактивация элементов
        grindButton.gameObject.SetActive(false);
        isStupaActive = false;
        isGrinding = false;
    }

    // Методы для активации и деактивации ступы
    public void ActivateStupa()
    {
        // Плавный переход
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 0f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 1f, transitionSpeed));

        isStupaActive = true;
        grindButton.gameObject.SetActive(true);
    }

    public void DeactivateStupa()
    {
        // Плавный переход
        StartCoroutine(FadeCanvas(craftingCanvasGroup, 1f, transitionSpeed));
        StartCoroutine(FadeCanvas(stupaCanvasGroup, 0f, transitionSpeed));

        isStupaActive = false;
        grindButton.gameObject.SetActive(false);
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
}
