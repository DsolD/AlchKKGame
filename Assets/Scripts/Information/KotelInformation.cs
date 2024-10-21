using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KotelInformation : MonoBehaviour
{
    public Dictionary<string, int> ingredients = new Dictionary<string, int>();


    public KotelInformation()
    {
        // Инициализация ингредиентов, если необходимо
        ingredients["Подорожник"] = 0;
        ingredients["Красный гриб"] = 0;
        ingredients["Алый цветок"] = 0;
    }

    // Метод для добавления ингредиента
    public void AddIngredient(string ingredient, int amount)
    {
        if (ingredients.ContainsKey(ingredient))
        {
            ingredients[ingredient] += amount;
        }
    }

    // Метод для создания зелья лечения
    public string CreateHealingPotion()
    {
        if (ingredients["Подорожник"] >= 3 && ingredients["Красный гриб"] >= 1)
        {
            ingredients["Подорожник"] -= 3;
            ingredients["Красный гриб"] -= 1;
            return "Зелье лечения создано!";
        }
        return "Недостаточно ингредиентов для зелья лечения.";
    }

    // Метод для создания зелья огнеупорности
    public string CreateFireResistancePotion()
    {
        if (ingredients["Алый цветок"] >= 3)
        {
            ingredients["Алый цветок"] -= 3;
            return "Зелье огнеупорности создано!";
        }
        return "Недостаточно ингредиентов для зелья огнеупорности.";
    }



    // Метод для получения типа зелья для других целей
    public string GetPotionType()
    {
        // Можно добавить логику, чтобы вернуть текущий создаваемый тип зелья
        return "Тип зелья"; // placeholder
    }
}