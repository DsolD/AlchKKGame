using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropImage : MonoBehaviour
{ 

    public LayerMask mycorkaLayer; // Слой "Mycorka"
    public Vector2 startPosition; // Целевая позиция для движения

    public Image kotel; // Image котёл, с которым проверяем коллизию
    public Camera mainCamera; //  Основная камера
    public Canvas canvas; // Canvas, на котором находится Image

  // public bool isMoving = false; // Флаг, показывающий, движется ли картинка

    // Список картинок
    public Image[] imagesToAnimate;

    // Флаг, показывающий, что все картинки в списке уже достигли своей цели
  //  public bool allImagesFinished = false;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        mainCamera = Camera.main;

        // Инициализируем движения для всех картинок в списке
        foreach (Image image in imagesToAnimate)
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

    //void Update()
    //{
    //    // Проверка, завершили ли все картинки движение
    //    allImagesFinished = true;
    //    foreach (Image image in imagesToAnimate)
    //    {
    //        MovingImage movingImage = image.gameObject.GetComponent<MovingImage>();
    //        if (!movingImage.hasFinished)
    //        {
    //            allImagesFinished = false; // Если хотя бы одна картинка не закончила движение, то allImagesFinished = false
    //            break; // Прерываем цикл
    //        }
    //    }
    //}

}

