using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public class KotelScript : MonoBehaviour
{

    public Button craft;
    public Text textpoison;


    private void Start()
    {
        craft.onClick.AddListener(CraftPoison);
    }

    public void CraftPoison()
    {
        KotelInformation kotelInfo = new KotelInformation();
        kotelInfo.AddIngredient("����������", 3);
        kotelInfo.AddIngredient("������� ����", 1);
        string healingPotionMessage = kotelInfo.CreateHealingPotion();
        //textpoison.text = healingPotionMessage;
        Debug.Log(healingPotionMessage); // �������� �������� ����� �������


        kotelInfo.AddIngredient("���� ������", 3);
        string fireResistancePotionMessage = kotelInfo.CreateFireResistancePotion();
        Debug.Log(fireResistancePotionMessage); // �������� �������� ����� �������������
    }

}
