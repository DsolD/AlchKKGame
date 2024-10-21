using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSaveingredient : MonoBehaviour
{

    public Button UpdateText;
    public Text mushroomText; // Для "Алый цветок"
    public Text подорожникText; // Для "Подорожник"
    public Text красныйГрибText; // Для "Красный гриб" 
    public KotelInformation KotelInformation; // Ссылка на объект KotelInformation

    private void Start()
    {
        UpdateText.onClick.AddListener(UpdateAllText);

        // Проверяем, что KotelInformation не null
        if (KotelInformation != null)
        {
            // Если не null, можно добавлять слушатель
            UpdateText.onClick.AddListener(UpdateAllText);
        }
        else
        {
            Debug.LogError("KotelInformation is null! Please check your settings.");
        }
    }

    public void UpdateAllText()
    {
        if (KotelInformation != null)
        {
            int mushroomCount = KotelInformation.ingredients["Алый цветок"]; // Исправлено
            int подорожникCount = KotelInformation.ingredients["Подорожник"];
            int красныйГрибCount = KotelInformation.ingredients["Красный гриб"];

            mushroomText.text = "Алый цветок: " + mushroomCount;
            подорожникText.text = "Подорожник: " + подорожникCount;
            красныйГрибText.text = "Красный гриб: " + красныйГрибCount;
        }
    }
}