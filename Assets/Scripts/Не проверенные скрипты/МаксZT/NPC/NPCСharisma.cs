using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public PlayerCharisma playerCharisma;
    public ItemSoldNPC itemSoldNPC; // Ссылка на предметы для продажи
    public float charismaBase; // Базовая харизма NPC

    private float charismaModifier; // Модификатор харизмы в зависимости от класса NPC
    private float charisma; // Текущая харизма NPC

    public void Start()
    {
        // Вычисляем модификатор харизмы в зависимости от класса NPC
        SetCharismaModifier();

        // Вычисляем текущую харизму
        charisma = charismaBase + charismaModifier;
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

    // Функция для проверки возможности продажи предмета
    //public bool CanSellItem(float offeredPrice)
    //{
    //    if (itemSoldNPC.items.Count == 0)
    //    {
    //        Debug.LogWarning("Нет доступных предметов для продажи");
    //        return false; // Нет предметов для продажи
    //    }

    //    // Проверяем, что предмет существует
    //    ItemSold itemForSale = itemSoldNPC.items[0]; // Предполагаем, что продается только первый предмет

        //// Проверяем, находится ли предлагаемая цена в пределах допустимого диапазона
        //if (offeredPrice < itemForSale.minPrice || offeredPrice > itemForSale.maxPrice)
        //{
        //    return false; // Цена некорректна
        //}

        // Вычисляем вероятность продажи
        //float probability = CalculateProbability(offeredPrice, itemForSale);

        // Проверяем, есть ли шанс на продажу
        //return Random.value <= probability; // Сделка состоялась или нет
    //}

    //Функция для расчета вероятности продажи
    //private float CalculateProbability(float offeredPrice, ItemSold itemForSale)
    //{
    //    // Вероятность продажи по минимальной цене всегда 100%
    //    if (offeredPrice == itemForSale.minPrice)
    //    {
    //        return 1f;
    //    }

    //    // Процент от максимальной цены, на который предлагаемая цена ближе к минимальной
    //    float priceDistancePercentage = (itemForSale.maxPrice - offeredPrice) / (itemForSale.maxPrice - itemForSale.minPrice);

    //    Вычисляем вероятность продажи
    //    float probability = charisma + priceDistancePercentage + playerCharisma.playerCharisma;

    //    // Ограничиваем вероятность продажи до 1
    //    return Mathf.Clamp(probability, 0f, 1f);
    //}

    // Функция для обработки удачной сделки
    //public void SuccessfulDeal()
    //{
    //    // Увеличиваем харизму на 0,1%
    //    charisma += 0.001f;
    //    Debug.Log("Харизма увеличена: " + charisma);
    //}

}
