using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
    public int LevelPotion;

    public Potion(string name, int amount, Sprite image, int price, int idPotion, int levelPotion)
    {
        Name = name;
        Amount = amount;
        Image = image;
        Price = price;
        IDPotion = idPotion;
        LevelPotion = levelPotion;
    }
}

public class NewInformation : MonoBehaviour
{

    public DataManager DataManager; // Ссылка на объект DataManager

    void Start()
    {
        // Получаем доступ к данным из DataManager
        DataManager = FindFirstObjectByType<DataManager>(); // Использовать FindFirstObjectByType

        // Использовать данные из dataManager.Ingredients, dataManager.Potions, dataManager.Coin
    }

    public static Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
    public static Dictionary<string, Potion> Potions = new Dictionary<string, Potion>();

    
    //  ЗЕЛЬЯ
    // Исцеленья
    public static string Healing_level1 = "Healing_level1"; // Исцеление 
    public static string Healing_level2 = "Healing_level2"; // Исцеление 
    public static string Healing_level3 = "Healing_level3"; // Исцеление 
    public static string Healing_level4 = "Healing_level4"; // Исцеление 

    // Выносливость
    public static string Stamina_level1 = "Stamina_level1"; // Выносливость 
    public static string Stamina_level2 = "Stamina_level2"; // Выносливость 
    public static string Stamina_level3 = "Stamina_level3"; // Выносливость 
    public static string Stamina_level4 = "Stamina_level4"; // Выносливость 

    // Скорость
    public static string Speed_level1 = "Speed_level1"; // Скорость 
    public static string Speed_level2 = "Speed_level2"; // Скорость 
    public static string Speed_level3 = "Speed_level3"; // Скорость 
    public static string Speed_level4 = "Speed_level4"; // Скорость 

    // Сопротивление
    public static string Resistance_level1 = "Resistance_level1"; // Сопротивление 
    public static string Resistance_level2 = "Resistance_level2"; // Сопротивление 
    public static string Resistance_level3 = "Resistance_level3"; // Сопротивление 
    public static string Resistance_level4 = "Resistance_level4"; // Сопротивление 

    // Сила воли
    public static string Power_will_level1 = "Power_will_level1"; // Сила воли 
    public static string Power_will_level2 = "Power_will_level2"; // Сила воли 
    public static string Power_will_level3 = "Power_will_level3"; // Сила воли 
    public static string Power_will_level4 = "Power_will_level4"; // Сила воли 

    // Скорость роста растений
    public static string Speed_growth_plant_level1 = "Speed_growth_plant_level1"; // Скорость роста растений 
    public static string Speed_growth_plant_level2 = "Speed_growth_plant_level2"; // Скорость роста растений 
    public static string Speed_growth_plant_level3 = "Speed_growth_plant_level3"; // Скорость роста растений 
    public static string Speed_growth_plant_level4 = "Speed_growth_plant_level4"; // Скорость роста растений
                                                                                  //  Ингредиенты

    // Ингредиенты
    public static string Red_Mushroom = "Red_Mushroom"; // Красный гриб 0
    public static string Big_Red_Mushroom = "Big_Red_Mushroom"; // Большой красный гриб 1
    public static string Black_Mushroom = "Black_Mushroom"; // Чёрный гриб 2
    public static string Green_Mushroom = "Green_Mushroom"; // Зелёный гриб 3
    public static string Blue_Mushroom = "Blue_Mushroom"; // Синий гриб 4

    public static string Scarlet_Aloe = "Scarlet_Aloe"; // Алая Алоя 5
    public static string Moon_Flower = "Moon_Flower"; // Цветок луны 6
    public static string Red_Lion_Flower = "Red_Lion_Flower"; // Цветок Красного льва 7
    public static string Mimosa = "Mimosa"; // Мимоза 8
    public static string Tin_Fabaceous = "Tin_Fabaceous"; // Оловянная фабацея 9
    public static string Green_Rabbit_Flower = "Green_Rabbit_Flower"; // Цветок Зелёного кролика 10
    public static string Persistent_Buttercup_Flower = "Persistent_Buttercup_Flower"; // Цветок стойкого лютика 11
    public static string Blue_Turtle_Flower = "Blue_Turtle_Flower"; // Цветок Синей черепахи 12
    public static string Winter_Stella_Bud = "Winter_Stella_Bud"; // Зимний Бутон стелларии 13
    public static string Flowerless_St_Johns_Wort = "Flowerless_St_Johns_Wort"; // Бесцветочный зверобой 14
    public static string Sun_Flower = "Sun_Flower"; // Цветок солнца 15
    public static string Sparkling_Fig = "Sparkling_Fig"; // Искрящийся фикус 16

    public static string Smoke_Bush_Stem = "Smoke_Bush_Stem"; // Стебель Дымового куста 17
    public static string Peat = "Peat"; // Торф 18
    public static string Ancient_Mandrake_Root = "Ancient_Mandrake_Root"; // Древний Корень Мандрагоры 19
    public static string Plantain = "Plantain"; // Подорожник 20
    public static string Silver_Lichen = "Silver_Lichen"; // Серебренный лишайник 21

    public static string Plantain_Extract = "Plantain_Extract"; // Экстракт подорожника 22
    public static string Green_Mushroom_Extract = "Green_Mushroom_Extract"; // Экстракт зелёного гриба 23
    public static string Red_Lion_Extract = "Red_Lion_Extract"; // Экстракт красного льва 24
    public static string Mimosa_Extract = "Mimosa_Extract"; // Экстракт мимозы 25
    public static string Silver_Lichen_Extract = "Silver_Lichen_Extract"; // Экстракт серебренного лишайника 26
    public static string Smoke_Bush_Stem_Extract = "Smoke_Bush_Stem_Extract"; // Экстракт из стебля дымового куста 27
    public static string Red_Mushroom_Extract = "Red_Mushroom_Extract"; // Экстракт Красного гриба 28
    public static string Tin_Fabaceous_Extract = "Tin_Fabaceous_Extract"; // Экстракт оловянной фабацеи 29
    public static string Black_Mushroom_Extract = "Black_Mushroom_Extract"; // Экстракт чёрного гриба 30

    public static string Mimosa_Seed_Oil = "Mimosa_Seed_Oil"; // Масло из семян мимозы 31
    public static string Blue_Mushroom_Oil = "Blue_Mushroom_Oil"; // Масло из синиго гриба 32

    // Монета
    public static int Coin;

    public static Dictionary<string, Ingredient> CreateIngredients()
    {
        return new Dictionary<string, Ingredient>()
        {
            { Information.Red_Mushroom, new Ingredient(Information.Red_Mushroom, 0, Resources.Load<Sprite>("Sprites/Red_Mushroom"), 0) },
            { Information.Big_Red_Mushroom, new Ingredient(Information.Big_Red_Mushroom, 0, Resources.Load<Sprite>("Sprites/Big_Red_Mushroom"), 1) },
            { Information.Black_Mushroom, new Ingredient(Information.Black_Mushroom, 0, Resources.Load<Sprite>("Sprites/Black_Mushroom"), 2) },
            { Information.Green_Mushroom, new Ingredient(Information.Green_Mushroom, 0, Resources.Load<Sprite>("Sprites/Green_Mushroom"), 3) },
            { Information.Blue_Mushroom, new Ingredient(Information.Blue_Mushroom, 0, Resources.Load<Sprite>("Sprites/Blue_Mushroom"), 4) },
            { Information.Scarlet_Aloe, new Ingredient(Information.Scarlet_Aloe, 0, Resources.Load<Sprite>("Sprites/Scarlet_Aloe"), 5) },
            { Information.Moon_Flower, new Ingredient(Information.Moon_Flower, 0, Resources.Load<Sprite>("Sprites/Moon_Flower"), 6) },
            { Information.Red_Lion_Flower, new Ingredient(Information.Red_Lion_Flower, 0, Resources.Load<Sprite>("Sprites/Red_Lion_Flower"), 7) },
            { Information.Mimosa, new Ingredient(Information.Mimosa, 0, Resources.Load<Sprite>("Sprites/Mimosa"), 8) },
            { Information.Tin_Fabaceous, new Ingredient(Information.Tin_Fabaceous, 0, Resources.Load<Sprite>("Sprites/Tin_Fabaceous"), 9) },
            { Information.Green_Rabbit_Flower, new Ingredient(Information.Green_Rabbit_Flower, 0, Resources.Load<Sprite>("Sprites/Green_Rabbit_Flower"), 10) },
            { Information.Persistent_Buttercup_Flower, new Ingredient(Information.Persistent_Buttercup_Flower, 5, Resources.Load<Sprite>("Sprites/Persistent_Buttercup_Flower"), 11) },
            { Information.Blue_Turtle_Flower, new Ingredient(Information.Blue_Turtle_Flower, 0, Resources.Load<Sprite>("Sprites/Blue_Turtle_Flower"), 12) },
            { Information.Winter_Stella_Bud, new Ingredient(Information.Winter_Stella_Bud, 0, Resources.Load<Sprite>("Sprites/Winter_Stella_Bud"), 13) },
            { Information.Flowerless_St_Johns_Wort, new Ingredient(Information.Flowerless_St_Johns_Wort, 6, Resources.Load<Sprite>("Sprites/Flowerless_St_Johns_Wort"), 14) },
            { Information.Sun_Flower, new Ingredient(Information.Sun_Flower, 0, Resources.Load<Sprite>("Sprites/Sun_Flower"), 15) },
            { Information.Sparkling_Fig, new Ingredient(Information.Sparkling_Fig, 0, Resources.Load<Sprite>("Sprites/Sparkling_Fig"), 16) },
            { Information.Smoke_Bush_Stem, new Ingredient(Information.Smoke_Bush_Stem, 0, Resources.Load<Sprite>("Sprites/Smoke_Bush_Stem"), 17) },
            { Information.Peat, new Ingredient(Information.Peat, 0, Resources.Load<Sprite>("Sprites/Peat"), 18) },
            { Information.Ancient_Mandrake_Root, new Ingredient(Information.Ancient_Mandrake_Root, 2, Resources.Load<Sprite>("Sprites/Ancient_Mandrake_Root"), 19) },
            { Information.Plantain, new Ingredient(Information.Plantain, 0, Resources.Load<Sprite>("Sprites/Plantain"), 20) },
            { Information.Silver_Lichen, new Ingredient(Information.Silver_Lichen, 0, Resources.Load<Sprite>("Sprites/Silver_Lichen"), 21) },
            { Information.Plantain_Extract, new Ingredient(Information.Plantain_Extract, 0, Resources.Load<Sprite>("Sprites/Plantain_Extract"), 22) },
            { Information.Green_Mushroom_Extract, new Ingredient(Information.Green_Mushroom_Extract, 0, Resources.Load<Sprite>("Sprites/Green_Mushroom_Extract"), 23) },
            { Information.Red_Lion_Extract, new Ingredient(Information.Red_Lion_Extract, 0, Resources.Load<Sprite>("Sprites/Red_Lion_Extract"), 24) },
            { Information.Mimosa_Extract, new Ingredient(Information.Mimosa_Extract, 0, Resources.Load<Sprite>("Sprites/Mimosa_Extract"), 25) },
            { Information.Silver_Lichen_Extract, new Ingredient(Information.Silver_Lichen_Extract, 0, Resources.Load<Sprite>("Sprites/Silver_Lichen_Extract"), 26) },
            { Information.Smoke_Bush_Stem_Extract, new Ingredient(Information.Smoke_Bush_Stem_Extract, 0, Resources.Load<Sprite>("Sprites/Smoke_Bush_Stem_Extract"), 27) },
            { Information.Red_Mushroom_Extract, new Ingredient(Information.Red_Mushroom_Extract, 0, Resources.Load<Sprite>("Sprites/Red_Mushroom_Extract"), 28) },
            { Information.Tin_Fabaceous_Extract, new Ingredient(Information.Tin_Fabaceous_Extract, 0, Resources.Load<Sprite>("Sprites/Tin_Fabaceous_Extract"), 29) },
            { Information.Black_Mushroom_Extract, new Ingredient(Information.Black_Mushroom_Extract, 0, Resources.Load<Sprite>("Sprites/Black_Mushroom_Extract"), 30) },
            { Information.Mimosa_Seed_Oil, new Ingredient(Information.Mimosa_Seed_Oil, 0, Resources.Load<Sprite>("Sprites/Mimosa_Seed_Oil"), 31) },
            { Information.Blue_Mushroom_Oil, new Ingredient(Information.Blue_Mushroom_Oil, 0, Resources.Load<Sprite>("Sprites/Blue_Mushroom_Oil"), 32) }
        };
    }

    public static Dictionary<string, Potion> CreatePotions()
    {
        return new Dictionary<string, Potion>()
        {
            // Исцеление
            { Information.Healing_level1, new Potion(Information.Healing_level1, 0, Resources.Load<Sprite>("Sprites/Healing"), 100, 0,1) },
            { Information.Healing_level2, new Potion(Information.Healing_level2, 0, Resources.Load<Sprite>("Sprites/Healing"), 100, 1,2) },
            { Information.Healing_level3, new Potion(Information.Healing_level3, 0, Resources.Load<Sprite>("Sprites/Healing"), 100, 2,3) },
            { Information.Healing_level4, new Potion(Information.Healing_level4, 0, Resources.Load<Sprite>("Sprites/Healing"), 100, 3,4) },

            // Выносливость
            { Information.Stamina_level1, new Potion(Information.Stamina_level1, 0, Resources.Load<Sprite>("Sprites/Stamina"), 200, 4,1) },
            { Information.Stamina_level2, new Potion(Information.Stamina_level2, 0, Resources.Load<Sprite>("Sprites/Stamina"), 200, 5,2) },
            { Information.Stamina_level3, new Potion(Information.Stamina_level3, 0, Resources.Load<Sprite>("Sprites/Stamina"), 200, 6,3) },
            { Information.Stamina_level4, new Potion(Information.Stamina_level4, 0, Resources.Load<Sprite>("Sprites/Stamina"), 200, 7,4) },

            // Скорость
            { Information.Speed_level1, new Potion(Information.Speed_level1, 0, Resources.Load<Sprite>("Sprites/Speed"), 150, 8,1) },
            { Information.Speed_level2, new Potion(Information.Speed_level2, 0, Resources.Load<Sprite>("Sprites/Speed"), 150, 9,2) },
            { Information.Speed_level3, new Potion(Information.Speed_level3, 0, Resources.Load<Sprite>("Sprites/Speed"), 150, 10,3) },
            { Information.Speed_level4, new Potion(Information.Speed_level4, 0, Resources.Load<Sprite>("Sprites/Speed"), 150, 11,4) },

            // Сопротивление
            { Information.Resistance_level1, new Potion(Information.Resistance_level1, 0, Resources.Load<Sprite>("Sprites/Resistance"), 300, 12,1) },
            { Information.Resistance_level2, new Potion(Information.Resistance_level2, 0, Resources.Load<Sprite>("Sprites/Resistance"), 300, 13,2) },
            { Information.Resistance_level3, new Potion(Information.Resistance_level3, 0, Resources.Load<Sprite>("Sprites/Resistance"), 300, 14,3) },
            { Information.Resistance_level4, new Potion(Information.Resistance_level4, 0, Resources.Load<Sprite>("Sprites/Resistance"), 300, 15,4) },

            // Сила воли
            { Information.Power_will_level1, new Potion(Information.Power_will_level1, 0, Resources.Load<Sprite>("Sprites/Power_will"), 250, 16,1) },
            { Information.Power_will_level2, new Potion(Information.Power_will_level2, 0, Resources.Load<Sprite>("Sprites/Power_will"), 250, 17,2) },
            { Information.Power_will_level3, new Potion(Information.Power_will_level3, 0, Resources.Load<Sprite>("Sprites/Power_will"), 250, 18,3) },
            { Information.Power_will_level4, new Potion(Information.Power_will_level4, 0, Resources.Load<Sprite>("Sprites/Power_will"), 250, 19,4) },
        };
    }

    public static void InitializeGameData()
    {
        // Заполняем словарь Ingredients
        Ingredients = CreateIngredients();

        // Заполняем словарь Potions
        Potions = CreatePotions();
    }


    


}

