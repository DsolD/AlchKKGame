using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Stupa_Miska : MonoBehaviour 
{
    // **Управление ингредиентами**
    public GameObject[] ingredients; // Массив для хранения всех префабов ингредиентов
    public int[] maxGrinds; // Массив для хранения максимального количества помолов для каждого ингредиента
    public Text ingredientNameText; // Текст для отображения названия ингредиента
    public Text grindCountText; // Текст для отображения количества оставшихся помолов

// надо добавить когда конкретный ингредиентом трогаешь то ингредент количество = maxGrinds

    // **Элементы UI**
    public Camera mainCamera; 
    public Canvas StupaCanvas; 
    public Canvas CraftingCanvas; 
    public Button grindButton; 
    public Image spoonImage; // loshka animation
    public Animator spoonAnimation; 
    public Button backButton; 
    public GameObject spoiledIngredientImage; // Изображение для испорченного ингредиента
    public Text spoiledIngredientText; // Текст для сообщения об испорченном ингредиенте

    // **Логика игры**
    private int currentIngredientIndex = 0; // Индекс текущего ингредиента в массиве
    private int remainingGrinds = 0; // Количество оставшихся помолов для текущего ингредиента

    public bool isStupaActive = false;// private стоит должно но да
    public bool isGrinding = false;  // private стоит должно но да

    private void Awake()
    {
        grindButton.gameObject.SetActive(false);
        // Инициализация элементов UI 
        spoiledIngredientImage.SetActive(false); 
        spoiledIngredientText.gameObject.SetActive(false);
    }

    private void Start()
    {
        // Добавление слушателей к кнопкам
        grindButton.onClick.AddListener(GrindIngredient);
        backButton.onClick.AddListener(BackToCrafting);

        // Начальная настройка для первого ингредиента 
        UpdateIngredientInfo();
    }

    // **Методы управления ингредиентами**
    public void SetIngredient(int index)
    {
        currentIngredientIndex = index;
        UpdateIngredientInfo(); 
    }

    // **Методы обновления UI**
    private void UpdateIngredientInfo()
    {
        // Обновление отображаемой информации на основе текущего ингредиента
        if (currentIngredientIndex < ingredients.Length)
        {
            // Получение информации о текущем ингредиенте
            string ingredientName = ingredients[currentIngredientIndex].name;
            remainingGrinds = maxGrinds[currentIngredientIndex];

            // Обновление UI
            ingredientNameText.text = ingredientName;
            grindCountText.text = $"Осталось помолов: {remainingGrinds}";
        }
        else
        {
            Debug.LogError("Индекс ингредиента вне диапазона!");
        }
    }

    // **Логика помола**
    public void GrindIngredient()
    {
        if (isStupaActive && !isGrinding) // Проверяем, активна ли ступа
        {
            spoonAnimation.Play("SpoonAnimation");
            isGrinding = true;
            remainingGrinds--;

            // Обновление количества помолов
            grindCountText.text = $"Осталось помолов: {remainingGrinds}";

            // Проверка, испорчен ли ингредиент
            if (remainingGrinds < 0)
            {
                // Отображение информации об испорченном ингредиенте 
                spoiledIngredientImage.SetActive(true);
                spoiledIngredientText.gameObject.SetActive(true);
                spoiledIngredientText.text = "Ингредиент испорчен!";
            }
            else
            {
                // Воспроизведение звука помола (можно добавить звуковые эффекты здесь)
                // ... 
            }
        }
    }

    public void ToggleStupa()
    {
        isStupaActive = !isStupaActive;
        // Обновляем UI или добавляем визуальный эффект
    }



    // **Методы навигации UI**
    public void BackToCrafting()
    {
        mainCamera.transform.position = new Vector2(CraftingCanvas.transform.position.x, CraftingCanvas.transform.position.y); 
        CraftingCanvas.gameObject.SetActive(true);
        StupaCanvas.gameObject.SetActive(false);
        grindButton.gameObject.SetActive(false);
        isStupaActive = false;
        isGrinding = false;
    }

    // **Методы для активации и деактивации ступы**
    public void ActivateStupa()
    {
        isStupaActive = true;
        grindButton.gameObject.SetActive(true);
        StupaCanvas.gameObject.SetActive(true);
        CraftingCanvas.gameObject.SetActive(false);
    }

    public void DeactivateStupa()
    {
        isStupaActive = false;
        grindButton.gameObject.SetActive(false);
        StupaCanvas.gameObject.SetActive(false);
        CraftingCanvas.gameObject.SetActive(true);
    }
    
}