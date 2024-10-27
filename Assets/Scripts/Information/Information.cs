using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;


[System.Serializable]
public class Ingredient
{
    public string Name;
    public int Amount;
    public Sprite Image; // Используйте Sprite вместо Texture2D для изображений в Unity
    public int IDIngredient;

    public Ingredient(string name, int amount, Sprite image, int idIngredient)
    {
        Name = name;
        Amount = amount;
        Image = image;
        IDIngredient = idIngredient;
    }
}

[System.Serializable]
public class Potion
{
    public string Name;
    public int Amount;
    public Sprite Image;
    public int Price;
    public int IDPotion;

    public Potion(string name, int amount, Sprite image, int price, int idPotion)
    {
        Name = name;
        Amount = amount;
        Image = image;
        Price = price;
        IDPotion = idPotion;
    }
}

public class Information : MonoBehaviour
{
    public static Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
    public static Dictionary<string, Potion> Potions = new Dictionary<string, Potion>();


    //  ЗЕЛЬЯ
    public static string Healing = "Healing"; // Исцеление 0
    public static string Stamina = "Stamina"; // Выносливость 1
    public static string Speed = "Speed"; // Скорость 2
    public static string Resistance = "Resistance"; // Сопротивление 3 
    public static string Power_will = "Power_will"; // Сила воли 4
    public static string Speed_growth_plant = "Speed_growth_plant"; // Скорость роста растений 5

    //  Ингредиенты

    public static string Red_Mushroom = "Red_Mushroom"; // Красный гриб 0
    public static string Big_Red_Mushroom = "Big_Red_Mushroom"; // Большой красный гриб 1
    public static string Black_Mushroom = "Black_Mushroom"; // Черный гриб 2 
    public static string Green_Mushroom = "Green_Mushroom"; // Зеленый гриб 3 
    public static string Blue_Mushroom = "Blue_Mushroom"; // Синий гриб 4

    public static string Scarlet_Aloe = "Scarlet_Aloe"; // Алая Алоя 5
    public static string Moon_Flower = "Moon_Flower"; // Цветок луны6
    public static string Red_Lion_Flower = "Red_Lion_Flower"; // Цветок Красного льва7
    public static string Mimosa = "Mimosa"; // Мимоза8
    public static string Tin_Fabaceous = "Tin_Fabaceous"; // Оловянная фабацея9
    public static string Green_Rabbit_Flower = "Green_Rabbit_Flower"; // Цветок Зелёного кролика10
    public static string Persistent_Buttercup_Flower = "Persistent_Buttercup_Flower"; // Цветок стойкого лютика
    public static string Blue_Turtle_Flower = "Blue_Turtle_Flower"; // Цветок Синей черепахи
    public static string Winter_Stella_Bud = "Winter_Stella_Bud"; // Зимний Бутон стелларии
    public static string Flowerless_St_Johns_Wort = "Flowerless_St_Johns_Wort"; // Бесцветочный зверобой
    public static string Sun_Flower = "Sun_Flower"; // Цветок солнца15
    public static string Sparkling_Fig = "Sparkling_Fig"; // Искрящийся фикус
    public static string Smoke_Bush_Stem = "Smoke_Bush_Stem"; // Стебель Дымового куста
    public static string Peat = "Peat"; // Торф18
    public static string Ancient_Mandrake_Root = "Ancient_Mandrake_Root"; // Древний Корень Мандрагоры
    public static string Plantain = "Plantain"; // Подорожник20
    public static string Silver_Lichen = "Silver_Lichen"; // Серебренный лишайник

    public static string Plantain_Extract = "Plantain_Extract"; // Экстракт подорожника22
    public static string Green_Mushroom_Extract = "Green_Mushroom_Extract"; // Экстракт зелёного гриба
    public static string Red_Lion_Extract = "Red_Lion_Extract"; // Экстракт красного льва24
    public static string Mimosa_Extract = "Mimosa_Extract"; // Экстракт мимозы
    public static string Silver_Lichen_Extract = "Silver_Lichen_Extract"; // Экстракт серебренного лишайника26
    public static string Smoke_Bush_Stem_Extract = "Smoke_Bush_Stem_Extract"; // Экстракт из стебля дымового куста
    public static string Red_Mushroom_Extract = "Red_Mushroom_Extract"; // Экстракт Красного гриба28
    public static string Tin_Fabaceous_Extract = "Tin_Fabaceous_Extract"; // Экстракт оловянной фабацеи
    public static string Black_Mushroom_Extract = "Black_Mushroom_Extract"; // Экстракт чёрного гриба30

    public static string Mimosa_Seed_Oil = "Mimosa_Seed_Oil"; // Масло из семян мимозы31
    public static string Blue_Mushroom_Oil = "Blue_Mushroom_Oil"; // Масло из синиго гриба 32

    // Монета
    public static int Coin;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Coin = " + Coin);
        }
    }

    //private void Awake()
    //{
    //    // Загружаем данные при запуске игры
    //    LoadData();
    //}

    //// При выходе из игры
    //private void OnApplicationQuit()
    //{
    //    // Сохраняем данные перед выходом
    //    SaveData();
    //}



    //public static void SaveData()
    //{

    //}

    //public static void LoadData()
    //{

    //}

}

