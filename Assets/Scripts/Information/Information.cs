using UnityEngine;


public class Information : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////
    
    public static int Healing = 0; // Лечебное
    public static int Stamina = 0; // Выносливость
    public static int Speed = 0; // Скорость
    public static int Resistance = 0; // Устойчивость
    public static int Power_will = 0; // Сила_воли
    public static int Speed_growth_plant = 0; // Скорость_роста_растения

    ////////////////////////////////////////////////////////////////////////
    public static int Plantain_Tincture = 0; // Настой Подорожника
    public static int Chamomile_Tincture = 0; // Настой Ромашек
    public static int Cranberry_Tincture = 0; // Настой Клюквы
    public static int Conifer_Forest_Tincture = 0; // Настой Хвой леса
    public static int Silver_Lichen_Tincture = 0; // Настой Серебреного лишайника
    public static int Cornflower_Tincture = 0; // Настой Васильков
    public static int Blueberry_Tincture = 0; // Настой Голубики
    public static int Tincture_of_Tin_fabaceous_Roots = 0; // Настой из корней оловянной фабацеи
    public static int Cave_Vine_Tincture = 0; // Настой из Пещерных лиан 

    public static int Red_Mushroom = 0; // Красный гриб
    public static int Big_Red_Mushroom = 0; // Большой красный гриб
    public static int Black_Mushroom = 0; // Черный гриб
    public static int Green_Mushroom = 0; // Зелёный гриб
    public static int Blue_Mushroom = 0; // Синий Гриб

    public static int Scarlet_Aloe = 0; // Алая Алоя
    public static int Moon_Flower = 0; // Цветок луны
    public static int Red_Lion_Flower = 0; // Цветок Красного льва
    public static int Green_Rabbit_Flower = 0; // Цветок Зелёного кролика
    public static int Hardy_Buttercup_Flower = 0; // Цветок стойкого лютика
    public static int Blue_Turtle_Flower = 0; // Цветок Синей черепахи
    public static int Open_Mimosa = 0; // Раскрытая Мимоза
    public static int Winter_Stella_Bud = 0; // Зимний Бутон стелларии
    public static int Сolourless_Beast = 0; // Бесцветный зверь

    public static int Sun_Flower = 0; // Цветок солнца
    public static int Sparkling_Fig = 0; // Искрящийся фикус

    public static int Stem_Smoky_Bush = 0; // Стебель Дымового куста
    public static int Oil_from_Yellow_Flower_Seeds = 0; // Масло из Семян Жёлтых Цветов
    public static int Oil_from_Blue_Flower_Seeds = 0; // Масло из Семян синих цветов
    public static int Peat = 0; // Торф
    public static int Ancient_Mandrake_Root = 0; // Древний Корень Мандрагоры

    ////////////////////////////////////////////////////////////////////////
    
    public static int MiniKey1 = 0;
    public static int MiniKey2 = 0;
    public static int MiniKey3 = 0;
    public static int SecretKey = 0;

    ////////////////////////////////////////////////////////////////////////

    private static int _coin = 0; // Используйте подчеркивание для обозначения частной переменной
    public static int Coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            // Если у вас есть текст монет, обновите его здесь:
            // coin_Text.text = "Монеты: " + Coin;
        }
    }

    private void Awake()
    {
        // LoadData();
        Debug.Log("Загрузилось");
    }

    // если вышло из игры
    private void OnApplicationQuit()
    {
        
        // Вызываем метод для сохранения данных
        // SaveData();
        Debug.Log("Сохранилось");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            Debug.Log("Coin = " + Coin);
        }
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("Coin", Coin);

        PlayerPrefs.SetInt("MiniKey1", MiniKey1);
        PlayerPrefs.SetInt("MiniKey2", MiniKey2);
        PlayerPrefs.SetInt("MiniKey3", MiniKey3);
        PlayerPrefs.SetInt("SecretKey", SecretKey);

        PlayerPrefs.SetInt("Healing", Healing);
        PlayerPrefs.SetInt("Stamina", Stamina);
        PlayerPrefs.SetInt("Speed", Speed);
        PlayerPrefs.SetInt("Resistance", Resistance);
        PlayerPrefs.SetInt("Power_will", Power_will);
        PlayerPrefs.SetInt("Speed_growth_plant", Speed_growth_plant);

        PlayerPrefs.SetInt("Plantain_Tincture", Plantain_Tincture);
        PlayerPrefs.SetInt("Chamomile_Tincture", Chamomile_Tincture);
        PlayerPrefs.SetInt("Cranberry_Tincture", Cranberry_Tincture);
        PlayerPrefs.SetInt("Conifer_Forest_Tincture", Conifer_Forest_Tincture);
        PlayerPrefs.SetInt("Silver_Lichen_Tincture", Silver_Lichen_Tincture);
        PlayerPrefs.SetInt("Cornflower_Tincture", Cornflower_Tincture);
        PlayerPrefs.SetInt("Blueberry_Tincture", Blueberry_Tincture);
        PlayerPrefs.SetInt("Tincture_of_Tin_fabaceous_Roots", Tincture_of_Tin_fabaceous_Roots);
        PlayerPrefs.SetInt("Cave_Vine_Tincture", Cave_Vine_Tincture);

        PlayerPrefs.SetInt("Red_Mushroom", Red_Mushroom);
        PlayerPrefs.SetInt("Big_Red_Mushroom", Big_Red_Mushroom);
        PlayerPrefs.SetInt("Black_Mushroom", Black_Mushroom);
        PlayerPrefs.SetInt("Green_Mushroom", Green_Mushroom);
        PlayerPrefs.SetInt("Blue_Mushroom", Blue_Mushroom);

        PlayerPrefs.SetInt("Scarlet_Aloe", Scarlet_Aloe);
        PlayerPrefs.SetInt("Moon_Flower", Moon_Flower);
        PlayerPrefs.SetInt("Red_Lion_Flower", Red_Lion_Flower);
        PlayerPrefs.SetInt("Open_Mimosa", Open_Mimosa);
        PlayerPrefs.SetInt("Green_Rabbit_Flower", Green_Rabbit_Flower);
        PlayerPrefs.SetInt("Hardy_Buttercup_Flower", Hardy_Buttercup_Flower);
        PlayerPrefs.SetInt("Blue_Turtle_Flower", Blue_Turtle_Flower);
        PlayerPrefs.SetInt("Winter_Stella_Bud", Winter_Stella_Bud);
        PlayerPrefs.SetInt("Сolourless_Beast", Сolourless_Beast);
        PlayerPrefs.SetInt("Sun_Flower", Sun_Flower);
        PlayerPrefs.SetInt("Sparkling_Fig", Sparkling_Fig);

        PlayerPrefs.SetInt("Stem_Smoky_Bush", Stem_Smoky_Bush);
        PlayerPrefs.SetInt("Oil_from_Yellow_Flower_Seeds", Oil_from_Yellow_Flower_Seeds);
        PlayerPrefs.SetInt("Oil_from_Blue_Flower_Seeds", Oil_from_Blue_Flower_Seeds);
        PlayerPrefs.SetInt("Peat", Peat);
        PlayerPrefs.SetInt("Ancient_Mandrake_Root", Ancient_Mandrake_Root);

        PlayerPrefs.Save();

    }

    public static void LoadData()
    {

        Coin = PlayerPrefs.GetInt("Coin", 0);

        MiniKey1 = PlayerPrefs.GetInt("MiniKey1", 0);
        MiniKey2 = PlayerPrefs.GetInt("MiniKey2", 0);
        MiniKey3 = PlayerPrefs.GetInt("MiniKey3", 0);
        SecretKey = PlayerPrefs.GetInt("SecretKey", 0);

        Healing = PlayerPrefs.GetInt("Healing", 0);
        Stamina = PlayerPrefs.GetInt("Stamina", 0);
        Speed = PlayerPrefs.GetInt("Speed", 0);
        Resistance = PlayerPrefs.GetInt("Resistance", 0);
        Power_will = PlayerPrefs.GetInt("Power_will", 0);
        Speed_growth_plant = PlayerPrefs.GetInt("Speed_growth_plant", 0);

        // Загрузка значений каждого ингредиента
        Plantain_Tincture = PlayerPrefs.GetInt("Plantain_Tincture", 0);
        Chamomile_Tincture = PlayerPrefs.GetInt("Chamomile_Tincture", 0);
        Cranberry_Tincture = PlayerPrefs.GetInt("Cranberry_Tincture", 0);
        Conifer_Forest_Tincture = PlayerPrefs.GetInt("Conifer_Forest_Tincture", 0);
        Silver_Lichen_Tincture = PlayerPrefs.GetInt("Silver_Lichen_Tincture", 0);
        Cornflower_Tincture = PlayerPrefs.GetInt("Cornflower_Tincture", 0);
        Blueberry_Tincture = PlayerPrefs.GetInt("Blueberry_Tincture", 0);
        Tincture_of_Tin_fabaceous_Roots = PlayerPrefs.GetInt("Tincture_of_Tin_fabaceous_Roots", 0);
        Cave_Vine_Tincture = PlayerPrefs.GetInt("Cave_Vine_Tincture", 0);

        Red_Mushroom = PlayerPrefs.GetInt("Red_Mushroom", 0);
        Big_Red_Mushroom = PlayerPrefs.GetInt("Big_Red_Mushroom", 0);
        Black_Mushroom = PlayerPrefs.GetInt("Black_Mushroom", 0);
        Green_Mushroom = PlayerPrefs.GetInt("Green_Mushroom", 0);
        Blue_Mushroom = PlayerPrefs.GetInt("Blue_Mushroom", 0);

        Scarlet_Aloe = PlayerPrefs.GetInt("Scarlet_Aloe", 0);
        Moon_Flower = PlayerPrefs.GetInt("Moon_Flower", 0);
        Red_Lion_Flower = PlayerPrefs.GetInt("Red_Lion_Flower", 0);
        Open_Mimosa = PlayerPrefs.GetInt("Open_Mimosa", 0);
        Green_Rabbit_Flower = PlayerPrefs.GetInt("Green_Rabbit_Flower", 0);
        Hardy_Buttercup_Flower = PlayerPrefs.GetInt("Hardy_Buttercup_Flower", 0);
        Blue_Turtle_Flower = PlayerPrefs.GetInt("Blue_Turtle_Flower", 0);
        Winter_Stella_Bud = PlayerPrefs.GetInt("Winter_Stella_Bud", 0);
        Сolourless_Beast = PlayerPrefs.GetInt("Colourless_Beast", 0);
        Sun_Flower = PlayerPrefs.GetInt("Sun_Flower", 0);
        Sparkling_Fig = PlayerPrefs.GetInt("Sparkling_Fig", 0);

        Stem_Smoky_Bush = PlayerPrefs.GetInt("Stem_Smoky_Bush", 0);
        Oil_from_Yellow_Flower_Seeds = PlayerPrefs.GetInt("Oil_from_Yellow_Flower_Seeds", 0);
        Oil_from_Blue_Flower_Seeds = PlayerPrefs.GetInt("Oil_from_Blue_Flower_Seeds", 0);
        Peat = PlayerPrefs.GetInt("Peat", 0);
        Ancient_Mandrake_Root = PlayerPrefs.GetInt("Ancient_Mandrake_Root", 0);

    }



}
