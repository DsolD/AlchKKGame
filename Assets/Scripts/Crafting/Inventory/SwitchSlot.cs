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

    void Start()
    {
        // Добавляем обработчики событий для кнопок
        CategoryButton1.onClick.AddListener(SwitchCategory1);
        CategoryButton2.onClick.AddListener(SwitchCategory2);
        CategoryButton3.onClick.AddListener(SwitchCategory3);
        CategoryButton4.onClick.AddListener(SwitchCategory4);

        // Деактивируем все объекты по умолчанию
        DeactivateAllGameObjects();
    }

    // Функция для деактивации всех объектов
    private void DeactivateAllGameObjects()
    {
        CategoryGameObject1.SetActive(false);
        CategoryGameObject2.SetActive(false);
        CategoryGameObject3.SetActive(false);
        CategoryGameObject4.SetActive(false);
    }

    // Функция для переключения категории 1
    void SwitchCategory1()
    {
        DeactivateAllGameObjects();
        CategoryGameObject1.SetActive(true);
    }

    // Функция для переключения категории 2
    void SwitchCategory2()
    {
        DeactivateAllGameObjects();
        CategoryGameObject2.SetActive(true);
    }

    // Функция для переключения категории 3
    void SwitchCategory3()
    {
        DeactivateAllGameObjects();
        CategoryGameObject3.SetActive(true);
    }

    // Функция для переключения категории 4
    void SwitchCategory4()
    {
        DeactivateAllGameObjects();
        CategoryGameObject4.SetActive(true);
    }
}
