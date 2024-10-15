using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MycorkaMovement : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    
    public Vector2 startPosition; // Целевая позиция для движения


    public Camera mainCamera; //  Основная камера
    public Canvas canvas; // Canvas, на котором находится Image

    public bool isDragging = false; // Флаг, показывающий, движется ли картинка

    void Start()
    {
        startPosition = transform.position; // Начальная позиция
    }



    void Update()
    {
        
    }

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
        }
    }
    // Обработчик отпускания левой кнопки мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем флаг перетаскивания
        isDragging = false;
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
