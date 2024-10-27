using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Добавили using UnityEngine.UI

public class NewMovingImage : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IDragHandler
{
    // Ссылки на объекты
    public GameObject ImagePrefab; // Префаб для создаваемого изображения 
    public Camera mainCamera; // Основная камера
    public Canvas canvas; // Canvas, на котором находится Image

    private Vector2 startPosition;
    private bool isDragging = false;
    private GameObject draggingImage; // Клонируемое изображение для перетаскивания 

    // Обработчик начала перетаскивания
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = true;

            // Создание клонированного изображения
            draggingImage = Instantiate(ImagePrefab, canvas.transform);
            draggingImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite; // Получение спрайта из компонента Image

            // Позиционирование клонированного изображения
            Vector2 mousePosition = eventData.position;
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            draggingImage.transform.position = worldPosition;
        }
    }

    // Обработчик перетаскивания
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 mousePosition = eventData.position;
            Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            draggingImage.transform.position = worldPosition;
        }
    }

    // Обработчик отпускания левой кнопки мыши
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            // Уничтожение клонированного изображения
            Destroy(draggingImage);
            isDragging = false;
        }
    }
}

