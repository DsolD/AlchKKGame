using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerAA : MonoBehaviour
{
    // Ссылки на объекты
    public GameObject InventoryPanel; // Панель инвентаря
    public GameObject IngredientButtonPrefab; // Префаб кнопки инвентаря
    public Transform InventoryGrid; // Трансформ, на котором будут располагаться кнопки
    public Text DescriptionsText; // Текстовое поле для названия ингредиента
    public Text NumberText; // Текстовое поле для количества
    public GameObject PrefabToSpawn; // Префаб, который нужно создавать

    // Словарь для хранения кнопок инвентаря (ключ - ID ингредиента, значение - кнопка)
    private Dictionary<int, GameObject> ingredientButtonDictionary = new Dictionary<int, GameObject>();

    // ID выбранного ингредиента
    public int selectedIngredientID;

    void Start()
    {
        // Добавляем информацию об ингредиентах из Information
        foreach (Ingredient ingredient in Information.Ingredients.Values)
        {
            AddIngredientToInventory(ingredient);
        }
    }

    // Метод для добавления ингредиента в инвентарь
    public void AddIngredientToInventory(Ingredient ingredient)
    {
        // Проверяем, есть ли уже кнопка для этого ингредиента
        if (ingredientButtonDictionary.ContainsKey(ingredient.IDIngredient))
        {
            // Если есть, увеличиваем количество
            int currentAmount = int.Parse(ingredientButtonDictionary[ingredient.IDIngredient].GetComponentInChildren<Text>().text);
            ingredientButtonDictionary[ingredient.IDIngredient].GetComponentInChildren<Text>().text = (currentAmount + ingredient.Amount).ToString();
        }
        else
        {
            // Создаем новую кнопку инвентаря
            GameObject ingredientButton = Instantiate(IngredientButtonPrefab.gameObject, InventoryGrid);
            ingredientButton.GetComponent<Image>().sprite = ingredient.Image;
            ingredientButton.GetComponentInChildren<Text>().text = ingredient.Amount.ToString();
            ingredientButton.name = ingredient.Name;

            // Добавляем кнопку в словарь
            ingredientButtonDictionary.Add(ingredient.IDIngredient, ingredientButton);

            // Назначаем обработчики событий для кнопки
            ingredientButton.GetComponent<Button>().onClick.AddListener(() => OnIngredientButtonClick(ingredient.IDIngredient));
        }
    }
    // Обработчик нажатия на кнопку ингредиента
    private void OnIngredientButtonClick(int ingredientID)
    {
        // Запоминаем ID выбранного ингредиента
        selectedIngredientID = ingredientID;

        // Получаем информацию об ингредиенте
        Ingredient ingredient = Information.Ingredients[Information.Ingredients.FirstOrDefault(x => x.Value.IDIngredient == ingredientID).Key];

        // Обновляем информацию о выбранном ингредиенте
        DescriptionsText.text = ingredient.Name;
        NumberText.text = ingredient.Amount.ToString();

        // Если количество больше 1, то делаем кнопку перетаскиваемой
        if (ingredient.Amount > 1)
        {
            ingredientButtonDictionary[ingredientID].GetComponent<NewMovingImage>().enabled = true;
        }
        else
        {
            ingredientButtonDictionary[ingredientID].GetComponent<NewMovingImage>().enabled = false;
        }

    }

    // Метод для использования выбранного ингредиента (срабатывает, например, по нажатию на кнопку "Использовать")
    public void UseSelectedIngredient()
    {
        if (selectedIngredientID != 0) // Проверка, что выбран какой-то ингредиент
        {
            // Получаем информацию об ингредиенте
            Ingredient selectedIngredient = Information.Ingredients[Information.Ingredients.FirstOrDefault(x => x.Value.IDIngredient == selectedIngredientID).Key];

            // Проверяем, достаточно ли ингредиента
            if (selectedIngredient.Amount > 0)
            {
                // Создаем экземпляр префаба
                Instantiate(PrefabToSpawn, transform.position, transform.rotation);

                // Уменьшаем количество ингредиента на 1
                selectedIngredient.Amount--;

                // Обновляем текст количества на кнопке
                ingredientButtonDictionary[selectedIngredientID].GetComponentInChildren<Text>().text = selectedIngredient.Amount.ToString();

                // Если количество ингредиента стало 0, отключаем кнопку перетаскивания
                if (selectedIngredient.Amount <= 0)
                {
                    ingredientButtonDictionary[selectedIngredientID].GetComponent<NewMovingImage>().enabled = false;
                }
            }
            else
            {
                // Выводим сообщение, что не хватает ингредиентов
                Debug.Log("Недостаточно ингредиентов!");
            }
        }
    }
}
