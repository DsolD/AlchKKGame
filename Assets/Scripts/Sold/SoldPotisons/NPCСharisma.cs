using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCharisma : MonoBehaviour
{
    public enum NPCClass
    {
        Крестьянин,
        Ремесленник,
        ЗажиточныйКрестьянин,
        Священник,
        ГлаваЦеха,
        Феодал,
        Торговец
    }

    public NPCClass npcClass;
    public PlayerCharisma playerCharisma; // Ссылка на скрипт игрока
    public float charismaBase; // Базовая харизма NPC

    public float charismaModifier; // Модификатор харизмы в зависимости от класса NPC

    public void Start()
    {
        // Вычисляем модификатор харизмы в зависимости от класса NPC
        SetCharismaModifier();
    }

    private void SetCharismaModifier()
    {
        switch (npcClass)
        {
            case NPCClass.Крестьянин:
                charismaModifier = 0f;
                break;
            case NPCClass.Ремесленник:
                charismaModifier = -0.05f;
                break;
            case NPCClass.ЗажиточныйКрестьянин:
                charismaModifier = -0.1f;
                break;
            case NPCClass.Священник:
                charismaModifier = -0.15f;
                break;
            case NPCClass.ГлаваЦеха:
                charismaModifier = -0.2f;
                break;
            case NPCClass.Феодал:
                charismaModifier = -0.25f;
                break;
            case NPCClass.Торговец:
                charismaModifier = -0.3f;
                break;
            default:
                charismaModifier = 0f;
                break; // На всякий случай
        }
    }

    // Метод для расчета вероятности продажи по удвоенной цене
    public float CalculateSellChance(float itemPrice)
    {
        // Проверяем, есть ли у игрока харизма для продажи по удвоенной цене
        if (playerCharisma.playerCharisma >= 0.1f)
        {
            float charismaMultiplier = 1f; // Начальный множитель харизмы

            switch (npcClass)
            {
                case NPCClass.Крестьянин:
                    charismaMultiplier = 1f; // Базовая харизма - 100%
                    break;
                case NPCClass.Ремесленник:
                    charismaMultiplier = 0.95f; // 5% меньше
                    break;
                case NPCClass.ЗажиточныйКрестьянин:
                    charismaMultiplier = 0.9f; // 10% меньше
                    break;
                case NPCClass.Священник:
                    charismaMultiplier = 0.85f; // 15% меньше
                    break;
                case NPCClass.ГлаваЦеха:
                    charismaMultiplier = 0.8f; // 20% меньше
                    break;
                case NPCClass.Феодал:
                    charismaMultiplier = 0.75f; // 25% меньше
                    break;
                case NPCClass.Торговец:
                    charismaMultiplier = 0.7f; // 30% меньше
                    break;
            }

            // Максимальная цена
            float maxPrice = itemPrice * 2;

            // Разница между максимальной ценой и предлагаемой ценой
            float priceDifference = maxPrice - itemPrice;

            // Процент от максимальной цены
            float priceDifferencePercent = (priceDifference / maxPrice) * 100;

            // Суммируем процент харизмы и процент от цены
            float totalChance = (playerCharisma.playerCharisma * 100 * charismaMultiplier) + priceDifferencePercent;

            // Возвращаем полученную вероятность
            return totalChance;
        }
        else
        {
            return 0; // Если харизмы недостаточно, вероятность равна 0
        }
    }

    // Метод для определения успешной сделки
    public bool IsSuccessfulTrade(float itemPrice, float tradePrice)
    {
        float midpoint = (itemPrice + (itemPrice * 2)) / 2; // Средняя точка между минимальной и максимальной ценой
        return tradePrice >= midpoint;
    }
}