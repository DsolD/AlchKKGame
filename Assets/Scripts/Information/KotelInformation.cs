using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KotelInformation : MonoBehaviour
{
    public Dictionary<string, int> ingredients = new Dictionary<string, int>();


    public KotelInformation()
    {
        // ������������� ������������, ���� ����������
        ingredients["����������"] = 0;
        ingredients["������� ����"] = 0;
        ingredients["���� ������"] = 0;
    }

    // ����� ��� ���������� �����������
    public void AddIngredient(string ingredient, int amount)
    {
        if (ingredients.ContainsKey(ingredient))
        {
            ingredients[ingredient] += amount;
        }
    }

    // ����� ��� �������� ����� �������
    public string CreateHealingPotion()
    {
        if (ingredients["����������"] >= 3 && ingredients["������� ����"] >= 1)
        {
            ingredients["����������"] -= 3;
            ingredients["������� ����"] -= 1;
            return "����� ������� �������!";
        }
        return "������������ ������������ ��� ����� �������.";
    }

    // ����� ��� �������� ����� �������������
    public string CreateFireResistancePotion()
    {
        if (ingredients["���� ������"] >= 3)
        {
            ingredients["���� ������"] -= 3;
            return "����� ������������� �������!";
        }
        return "������������ ������������ ��� ����� �������������.";
    }



    // ����� ��� ��������� ���� ����� ��� ������ �����
    public string GetPotionType()
    {
        // ����� �������� ������, ����� ������� ������� ����������� ��� �����
        return "��� �����"; // placeholder
    }
}