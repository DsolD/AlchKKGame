using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSaveingredient : MonoBehaviour
{

    public Button UpdateText;
    public Text mushroomText; // ��� "���� ������"
    public Text ����������Text; // ��� "����������"
    public Text �����������Text; // ��� "������� ����" 
    public KotelInformation KotelInformation; // ������ �� ������ KotelInformation

    private void Start()
    {
        UpdateText.onClick.AddListener(UpdateAllText);

        // ���������, ��� KotelInformation �� null
        if (KotelInformation != null)
        {
            // ���� �� null, ����� ��������� ���������
            UpdateText.onClick.AddListener(UpdateAllText);
        }
        else
        {
            Debug.LogError("KotelInformation is null! Please check your settings.");
        }
    }

    public void UpdateAllText()
    {
        if (KotelInformation != null)
        {
            int mushroomCount = KotelInformation.ingredients["���� ������"]; // ����������
            int ����������Count = KotelInformation.ingredients["����������"];
            int �����������Count = KotelInformation.ingredients["������� ����"];

            mushroomText.text = "���� ������: " + mushroomCount;
            ����������Text.text = "����������: " + ����������Count;
            �����������Text.text = "������� ����: " + �����������Count;
        }
    }
}