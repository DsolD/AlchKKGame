using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingImage : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    public LayerMask mycorkaLayer; // Слой "Mycorka"
    public Vector2 startPosition; // Целевая позиция для движения

    public Image kotel; // Image котёл, с которым проверяем коллизию
    public Camera mainCamera; //  Основная камера
    public Canvas canvas; // Canvas, на котором находится Image

    public bool isDragging = false; // Флаг, показывающий, движется ли картинка

    void Start()
    {
        startPosition = transform.position; // Начальная позиция
    }

    void FixedUpdate()
    {
        // Проверяем, не нажата ли левая кнопка мыши
        if (!Input.GetMouseButton(0))
        {
            // Проверяем коллизию со слоем "Mycorka"
            if (Physics2D.OverlapPoint(transform.position, mycorkaLayer))
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckKotelCollision(PointerEventData eventData)
    {
        if (kotel != null) // Проверяем, что kotel не null
        {
            RectTransform kotelRect = kotel.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(kotelRect, eventData.position, mainCamera))
            {
                Destroy(gameObject);
            }
        }
    }

    // Обработчик нажатия левой кнопки мыши
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            startPosition = transform.position;
            isDragging = true;
        }
    }

    // Обработчик перетаскивания
    public void OnDrag(PointerEventData eventData)
    {
        // Если происходит перетаскивание
        if (isDragging)
        {
            // Получаем позицию мыши в мировых координатах (Vector2)
            Vector2 mousePosition = eventData.position;
            // Устанавливаем новое положение Image (Vector2)
            transform.position = mousePosition;
            // Проверяем коллизию с котлом
            CheckKotelCollision(eventData);
        }
    }




    // Обработчик отпускания левой кнопки мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем флаг перетаскивания
        isDragging = false;

        // Проверяем коллизию с "Mycorka"
        if (Physics2D.OverlapCircle(transform.position, 0.1f, mycorkaLayer))
        {
            Destroy(gameObject);
        }
    }

    // Обработчик начала перетаскивания
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Ничего не делаем, так как перетаскивание начинается при нажатии левой кнопки
    }

    // Обработчик окончания перетаскивания
    public void OnEndDrag(PointerEventData eventData)
    {
        // Ничего не делаем, так как перетаскивание заканчивается при отпускании левой кнопки
    }
}
