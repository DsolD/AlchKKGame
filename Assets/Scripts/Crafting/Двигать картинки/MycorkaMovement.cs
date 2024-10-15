using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MycorkaMovement : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    
    public Vector2 startPosition; // ������� ������� ��� ��������


    public Camera mainCamera; //  �������� ������
    public Canvas canvas; // Canvas, �� ������� ��������� Image

    public bool isDragging = false; // ����, ������������, �������� �� ��������

    void Start()
    {
        startPosition = transform.position; // ��������� �������
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

    // ���������� ��������������
    public void OnDrag(PointerEventData eventData)
    {
        // ���� ���������� ��������������
        if (isDragging)
        {
            // �������� ������� ���� � ������� ����������� (Vector2)
            Vector2 mousePosition = eventData.position;
            // ������������� ����� ��������� Image (Vector2)
            transform.position = mousePosition;
        }
    }
    // ���������� ���������� ����� ������ ����
    public void OnPointerUp(PointerEventData eventData)
    {
        // ���������� ���� ��������������
        isDragging = false;
    }

    // ���������� ������ ��������������
    public void OnBeginDrag(PointerEventData eventData)
    {
        // ������ �� ������, ��� ��� �������������� ���������� ��� ������� ����� ������
    }

    // ���������� ��������� ��������������
    public void OnEndDrag(PointerEventData eventData)
    {
        // ������ �� ������, ��� ��� �������������� ������������� ��� ���������� ����� ������
    }

}
