using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerAA : MonoBehaviour
{
    // Ссылки на объекты
    public GameObject InventoryPanel; // Панель инвентаря
    public Button idgreditionButton;
    public PreFabNew IngredientButtonPrefab; // Префаб кнопки инвентаря
    public Transform InventoryGrid; // Трансформ, на котором будут располагаться кнопки
    public Text DescriptionsText; // Текстовое поле для названия ингредиента
    public Text NumberText; // Текстовое поле для количества

    // Словарь для хранения кнопок инвентаря (ключ - ID ингредиента, значение - кнопка)
    private Dictionary<int, GameObject> ingredientButtons = new Dictionary<int, GameObject>();

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
        if (ingredientButtons.ContainsKey(ingredient.IDIngredient))
        {
            // Если есть, увеличиваем количество
            int currentAmount = int.Parse(ingredientButtons[ingredient.IDIngredient].GetComponentInChildren<Text>().text);
            ingredientButtons[ingredient.IDIngredient].GetComponentInChildren<Text>().text = (currentAmount + ingredient.Amount).ToString();
        }
        else
        {
            // Создаем новую кнопку инвентаря
            GameObject ingredientButton = Instantiate(IngredientButtonPrefab.gameObject, InventoryGrid);
            ingredientButton.GetComponent<Image>().sprite = ingredient.Image;
            ingredientButton.GetComponentInChildren<Text>().text = ingredient.Amount.ToString();
            ingredientButton.name = ingredient.Name;

            // Добавляем кнопку в словарь
            ingredientButtons.Add(ingredient.IDIngredient, ingredientButton);

            // Назначаем обработчики событий для кнопки
            ingredientButton.GetComponent<Button>().onClick.AddListener(() => OnIngredientButtonClick(ingredient.IDIngredient));
        }
    }

    // Обработчик нажатия на кнопку ингредиента
    private void OnIngredientButtonClick(int ingredientID)
    {
        // Получаем информацию об ингредиенте
        Ingredient ingredient = Information.Ingredients[Information.Ingredients.FirstOrDefault(x => x.Value.IDIngredient == ingredientID).Key];

        // Обновляем информацию о выбранном ингредиенте
        DescriptionsText.text = ingredient.Name;
        NumberText.text = ingredient.Amount.ToString();

        // Если количество больше 1, то делаем кнопку перетаскиваемой
        if (ingredient.Amount > 1)
        {
            ingredientButtons[ingredientID].GetComponent<NewMovingImage>().enabled = true;
        }
        else
        {
            ingredientButtons[ingredientID].GetComponent<NewMovingImage>().enabled = false;
        }
    }
}
