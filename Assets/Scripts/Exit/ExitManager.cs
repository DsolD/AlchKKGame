using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    // ������ ��� �������� ����� �������
    public Button StreetButton;
    public Button BedRoomButton;

    // ����� ������-�� :(
    public Button ShopButton;
    public Button TopDownButton;

    void Start()
    {
        // ���������� ������������ ������
        StreetButton.onClick.AddListener(LoadStreetScene);
        BedRoomButton.onClick.AddListener(LoadBedRoomScene);

        // ����� ������-�� :(
        ShopButton.onClick.AddListener(LoadShopScene);
        TopDownButton.onClick.AddListener(LoadTopDownScene);
    }

    // ������ ��� �������� ����
    public void LoadStreetScene()
    {
        SceneManager.LoadScene("StreetScene"); // �������� "StreetScene" �� ��� ����� ����� "�����"
    }

    public void LoadBedRoomScene()
    {
        SceneManager.LoadScene("BedRoomScene"); // �������� "BedRoomScene" �� ��� ����� ����� "�������"
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene"); // �������� "ShopScene" �� ��� ����� ����� "�������"
    }

    public void LoadTopDownScene()
    {
        SceneManager.LoadScene("TopDownScene"); // �������� "TopDownScene" �� ��� ����� ����� "��� ������"
    }

}