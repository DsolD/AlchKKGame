using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRepire : MonoBehaviour
{
    public Button HelpButton;
    public Image[] AllSprite; // ������ Image, ������� ����� ����������
    public Transform parentTransform; // ��������� ������������� ������� ��� ��������� �����������

    private Image[] imageInstances; // ������ ��� �������� ��������� ����������� Image

    public LayerMask mycorkaLayer; // ���� "Mycorka"
    public Vector2 startPosition; // ������� ������� ��� ��������

    public Image kotel; // Image ����, � ������� ��������� ��������
    public Camera mainCamera; //  �������� ������
    public Canvas canvas; // Canvas, �� ������� ��������� Image

    void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);
        HelpButton.onClick.AddListener(Gods);

        // �������������� ������ imageInstances
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
        // ���������, �� ���������� �� �����������
        for (int i = 0; i < AllSprite.Length; i++)
        {
            if (imageInstances[i] == null)
            {
                // ���� ����������� ����������, ������� ��� ������
                imageInstances[i] = CreateImageInstance(AllSprite[i]);
            }
            else
            {
                // ���� ����������� �� ����������, ������ ���������� ���
                imageInstances[i].gameObject.SetActive(true);
            }
        }
    }

    // ������� ��� �������� ������ ���������� Image
    private Image CreateImageInstance(Image image)
    {
        // ������� ����� GameObject
        GameObject newImageObject = new GameObject("Benograd");
        newImageObject.transform.SetParent(parentTransform); // ������������� ������������ ������
        newImageObject.transform.localPosition = startPosition; // ������������� ��������� �������

        // ������� ��������� Image
        Image newImage = newImageObject.AddComponent<Image>();
        newImage.sprite = image.sprite; // ������������� ������

        // ����������� ���� ����������� (�� �������)
        newImage.color = Color.white;

        return newImage;
    }

    public void Gods()
    {
        foreach (Image image in imageInstances)
        {
            // ������� ��������� "MovingImage" ��� ������ �������� 
            MovingImage movingImage = image.gameObject.AddComponent<MovingImage>();


            movingImage.startPosition = startPosition;
            movingImage.mycorkaLayer = mycorkaLayer; // ������������� ���� "Mycorka" 

            movingImage.kotel = kotel; // ������������� ����� ��� �������� ��������
            movingImage.mainCamera = mainCamera; // ������������� �������� ������
            movingImage.canvas = canvas; // ������������� Canvas

        }
    }



}

