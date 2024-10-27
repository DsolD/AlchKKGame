using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using UnityEngine.UI;


public class gggg : MonoBehaviour
{
    public  Dictionary<string, Ingredientf> Ingredients = new Dictionary<string, Ingredientf>();
    public  Dictionary<string, Potionf> Potions = new Dictionary<string, Potionf>();
}

[System.Serializable]
public class Ingredientf
{
    public string Name;
    public int Amount;
    public Sprite Image; // Используйте Sprite вместо Texture2D для изображений в Unity
    public int IDIngredient;

    public Ingredientf(string name, int amount, Sprite image, int idIngredient)
    {
        Name = name;
        Amount = amount;
        Image = image;
        IDIngredient = idIngredient;
    }
}

[System.Serializable]
public class Potionf
{
    public string Name;
    public int Amount;
    public Sprite Image;
    public int Price;
    public int IDPotion;

    public Potionf(string name, int amount, Sprite image, int price, int idPotion)
    {
        Name = name;
        Amount = amount;
        Image = image;
        Price = price;
        IDPotion = idPotion;
    }
}