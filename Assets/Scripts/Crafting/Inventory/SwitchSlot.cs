using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlot : MonoBehaviour
{
    // Public GameObjects ��� ������ ���������
    public GameObject CategoryGameObject1;
    public GameObject CategoryGameObject2;
    public GameObject CategoryGameObject3;
    public GameObject CategoryGameObject4;

    // ������
    public Button CategoryButton1;
    public Button CategoryButton2;
    public Button CategoryButton3;
    public Button CategoryButton4;

    void Start()
    {
        // ��������� ����������� ������� ��� ������
        CategoryButton1.onClick.AddListener(SwitchCategory1);
        CategoryButton2.onClick.AddListener(SwitchCategory2);
        CategoryButton3.onClick.AddListener(SwitchCategory3);
        CategoryButton4.onClick.AddListener(SwitchCategory4);

        // ������������ ��� ������� �� ���������
        DeactivateAllGameObjects();
    }

    // ������� ��� ����������� ���� ��������
    private void DeactivateAllGameObjects()
    {
        CategoryGameObject1.SetActive(false);
        CategoryGameObject2.SetActive(false);
        CategoryGameObject3.SetActive(false);
        CategoryGameObject4.SetActive(false);
    }

    // ������� ��� ������������ ��������� 1
    void SwitchCategory1()
    {
        DeactivateAllGameObjects();
        CategoryGameObject1.SetActive(true);
    }

    // ������� ��� ������������ ��������� 2
    void SwitchCategory2()
    {
        DeactivateAllGameObjects();
        CategoryGameObject2.SetActive(true);
    }

    // ������� ��� ������������ ��������� 3
    void SwitchCategory3()
    {
        DeactivateAllGameObjects();
        CategoryGameObject3.SetActive(true);
    }

    // ������� ��� ������������ ��������� 4
    void SwitchCategory4()
    {
        DeactivateAllGameObjects();
        CategoryGameObject4.SetActive(true);
    }
}
