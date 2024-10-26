using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlot : MonoBehaviour
{
    // Public GameObjects для каждой категории
    public GameObject CategoryGameObject1;
    public GameObject CategoryGameObject2;
    public GameObject CategoryGameObject3;
    public GameObject CategoryGameObject4;

    // Кнопки
    public Button CategoryButton1;
    public Button CategoryButton2;
    public Button CategoryButton3;
    public Button CategoryButton4;

    // Переменная для хранения выбранной категории
    public int selectedCategory = 1; // По умолчанию - категория 1

    void Start()
    {
        // Добавляем обработчики событий для кнопок
        CategoryButton1.onClick.AddListener(SwitchCategory1);
        CategoryButton2.onClick.AddListener(SwitchCategory2);
        CategoryButton3.onClick.AddListener(SwitchCategory3);
        CategoryButton4.onClick.AddListener(SwitchCategory4);

        // Деактивируем все объекты по умолчанию
        DeactivateAllGameObjects();

        // Активируем начальную категорию
        SwitchCategory(selectedCategory);
    }

    // Функция для деактивации всех объектов
    private void DeactivateAllGameObjects()
    {
        CategoryGameObject1.SetActive(false);
        CategoryGameObject2.SetActive(false);
        CategoryGameObject3.SetActive(false);
        CategoryGameObject4.SetActive(false);
    }

    // Объединим функции переключения в одну
    public void SwitchCategory(int category)
    {
        DeactivateAllGameObjects();
        switch (category)
        {
            case 1: CategoryGameObject1.SetActive(true); break;

            case 2:
                CategoryGameObject2.SetActive(true);
                break;
            case 3:
                CategoryGameObject3.SetActive(true);
                break;
            case 4:
                CategoryGameObject4.SetActive(true);
                break;
        }
        // Обновим "selectedCategory"
        selectedCategory = category;
    }

    // Функция для переключения категории 1
    public void SwitchCategory1()
    {
        SwitchCategory(1);
    }

    // Функция для переключения категории 2
    void SwitchCategory2()
    {
        SwitchCategory(2);
    }

    // Функция для переключения категории 3
    void SwitchCategory3()
    {
        SwitchCategory(3);
    }

    // Функция для переключения категории 4
    void SwitchCategory4()
    {
        SwitchCategory(4);
    }
}
