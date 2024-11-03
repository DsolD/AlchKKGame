using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemSoldNPC : MonoBehaviour
{
    public List<ItemSold> items = new List<ItemSold>();

    // Метод для получения рандомного элемента из словаря
    public ItemSold GetRandomItem()
    {
        // Получаем список всех ключей из словаря NewInformation.Potions
        string[] potionKeys = NewInformation.Potions.Keys.ToArray();

        // Генерируем случайное число в диапазоне от 0 до количества ключей в словаре
        int randomIndex = Random.Range(0, potionKeys.Length);

        // Получаем ключ по случайному индексу
        string randomPotionKey = potionKeys[randomIndex];

        // Получаем зелье из словаря NewInformation.Potions по ключу
        Potion randomPotion = NewInformation.Potions[randomPotionKey];

        // Создаем объект ItemSold, используя информацию из случайного зелья
        ItemSold newItem = new ItemSold
        {
            id = randomPotion.IDPotion,
            name = randomPotion.Name,
            img = randomPotion.Image,
            Price = randomPotion.Price,
            amout = randomPotion.Amount
        };

        // Возвращаем созданный ItemSold
        return newItem;
    }

    // Метод для продажи рандомного зелья 
    public void SellRandomItem()
    {
        // Получаем рандомное зелье
        ItemSold itemToSell = GetRandomItem();

        // Добавляем полученное зелье в список items 
        items.Add(itemToSell);

        // Выводим информацию о проданном зелье в консоль (для отладки)
        Debug.Log("Продано зелье: " + itemToSell.name);
    }
}

[System.Serializable]
public class ItemSold
{
    public int id; // айди хзелья
    public string name; // названия зелья
    public Sprite img; // картинка зелья
    public float Price; // стоимость 1 зелья 
    public int amout; // сколько зелей он возьмет
}

