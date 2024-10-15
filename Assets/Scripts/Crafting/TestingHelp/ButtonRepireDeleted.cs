using UnityEngine;
using UnityEngine.UI;

public class ButtonRepireDeleted : MonoBehaviour
{
    public Button HelpButton;
    public Image[] AllSprite; // ������ Image, ������� ����� ����������

    private void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);

        // ������� �������� ��� Image
        foreach (Image image in AllSprite)
        {
            image.gameObject.SetActive(true);
        }
    }

    void Recoveries()
    {
        // ���������, �� ���������� �� �����������
        for (int i = 0; i < AllSprite.Length; i++)
        {
            if (AllSprite[i] == null)
            {
                // ���� ����������� ����������, ������� ��� ������
                AllSprite[i] = Instantiate(AllSprite[0], transform);
                AllSprite[i].gameObject.SetActive(true);
            }
            else if (AllSprite[i].gameObject.activeInHierarchy == false)
            {
                // �������� ������� �����������
                Destroy(AllSprite[i].gameObject);
                // �������� ������ �����������
                AllSprite[i] = Instantiate(AllSprite[0], transform);
                AllSprite[i].gameObject.SetActive(true);
            }
            else
            {
                // ���� ����������� �� ����������, ������ ���������� ���
                AllSprite[i].gameObject.SetActive(true);
            }
        }
    }
}

