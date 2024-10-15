using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRepire : MonoBehaviour
{
    public Button HelpButton;
    public Image[] AllSprite; // Массив Image, которые нужно показывать
    public Transform parentTransform; // Трансформ родительского объекта для созданных изображений

    private Image[] imageInstances; // Массив для хранения созданных экземпляров Image

    public LayerMask mycorkaLayer; // Слой "Mycorka"
    public Vector2 startPosition; // Целевая позиция для движения

    public Image kotel; // Image котёл, с которым проверяем коллизию
    public Camera mainCamera; //  Основная камера
    public Canvas canvas; // Canvas, на котором находится Image

    void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);
        HelpButton.onClick.AddListener(Gods);

        // Инициализируем массив imageInstances
        imageInstances = new Image[AllSprite.Length];
        for (int i = 0; i < AllSprite.Length; i++)
        {
            imageInstances[i] = null;
        }


        canvas = GetComponentInParent<Canvas>();
        mainCamera = Camera.main;
    }

    void Recoveries()
    {
        // Проверяем, не уничтожены ли изображения
        for (int i = 0; i < AllSprite.Length; i++)
        {
            if (imageInstances[i] == null)
            {
                // Если изображение уничтожено, создаем его заново
                imageInstances[i] = CreateImageInstance(AllSprite[i]);
            }
            else
            {
                // Если изображение не уничтожено, просто показываем его
                imageInstances[i].gameObject.SetActive(true);
            }
        }
    }

    // Функция для создания нового экземпляра Image
    private Image CreateImageInstance(Image image)
    {
        // Создаем новый GameObject
        GameObject newImageObject = new GameObject("Benograd");
        newImageObject.transform.SetParent(parentTransform); // Устанавливаем родительский объект
        newImageObject.transform.localPosition = startPosition; // Устанавливаем начальную позицию

        // Создаем компонент Image
        Image newImage = newImageObject.AddComponent<Image>();
        newImage.sprite = image.sprite; // Устанавливаем спрайт

        // Настраиваем цвет изображения (по желанию)
        newImage.color = Color.white;

        return newImage;
    }

    public void Gods()
    {
        foreach (Image image in imageInstances)
        {
            // Создаем компонент "MovingImage" для каждой картинки 
            MovingImage movingImage = image.gameObject.AddComponent<MovingImage>();


            movingImage.startPosition = startPosition;
            movingImage.mycorkaLayer = mycorkaLayer; // Устанавливаем слой "Mycorka" 

            movingImage.kotel = kotel; // Устанавливаем котел для проверки коллизии
            movingImage.mainCamera = mainCamera; // Устанавливаем основную камеру
            movingImage.canvas = canvas; // Устанавливаем Canvas

        }
    }



}

