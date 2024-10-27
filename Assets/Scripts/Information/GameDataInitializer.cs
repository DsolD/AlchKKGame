using UnityEngine;
using System.Collections.Generic;

public class GameDataInitializer : MonoBehaviour
{
    void Start()
    {
        // Заполняем словарь Ingredients
        Information.Ingredients = new Dictionary<string, Ingredient>
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
               { Information.Blue_Mushroom_Oil, new Ingredient(Information.Blue_Mushroom_Oil, 0, Resources.Load<Sprite>("Sprites/Blue_Mushroom_Oil"), 32) } // где нолики это их количества
        
    };

        // Заполняем словарь Potions
        Information.Potions = new Dictionary<string, Potion>
           {
               { Information.Healing, new Potion(Information.Healing, 0, Resources.Load<Sprite>("Sprites/Healing"), 100, 0) }, // ЦЕНА блять 100
               { Information.Stamina, new Potion(Information.Stamina, 0, Resources.Load<Sprite>("Sprites/Stamina"), 200, 1) },
               { Information.Speed, new Potion(Information.Speed, 0, Resources.Load<Sprite>("Sprites/Speed"), 150, 2) },
               { Information.Resistance, new Potion(Information.Resistance, 0, Resources.Load<Sprite>("Sprites/Resistance"), 300, 3) },
               { Information.Power_will, new Potion(Information.Power_will, 0, Resources.Load<Sprite>("Sprites/Power_will"), 250, 4) },
               // ... Добавьте оставшиеся зелья 
           };
    }
}
