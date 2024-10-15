using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingImage : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    public LayerMask mycorkaLayer; // ���� "Mycorka"
    public Vector2 startPosition; // ������� ������� ��� ��������

    public Image kotel; // Image ����, � ������� ��������� ��������
    public Camera mainCamera; //  �������� ������
    public Canvas canvas; // Canvas, �� ������� ��������� Image

    public bool isDragging = false; // ����, ������������, �������� �� ��������

    void Start()
    {
        startPosition = transform.position; // ��������� �������
    }

    void FixedUpdate()
    {
        // ���������, �� ������ �� ����� ������ ����
        if (!Input.GetMouseButton(0))
        {
            // ��������� �������� �� ����� "Mycorka"
            if (Physics2D.OverlapPoint(transform.position, mycorkaLayer))
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckKotelCollision(PointerEventData eventData)
    {
        if (kotel != null) // ���������, ��� kotel �� null
        {
            RectTransform kotelRect = kotel.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(kotelRect, eventData.position, mainCamera))
            {
                Destroy(gameObject);
            }
        }
    }

    // ���������� ������� ����� ������ ����
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
            // ��������� �������� � ������
            CheckKotelCollision(eventData);
        }
    }




    // ���������� ���������� ����� ������ ����
    public void OnPointerUp(PointerEventData eventData)
    {
        // ���������� ���� ��������������
        isDragging = false;

        // ��������� �������� � "Mycorka"
        if (Physics2D.OverlapCircle(transform.position, 0.1f, mycorkaLayer))
        {
            Destroy(gameObject);
        }
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
