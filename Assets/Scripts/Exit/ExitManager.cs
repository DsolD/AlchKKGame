using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    // Кнопки для перехода между сценами
    public Button StreetButton;
    public Button BedRoomButton;

    // улица вообще-то :(
    public Button ShopButton;
    public Button TopDownButton;

    void Start()
    {
        // Добавление обработчиков кликов
        StreetButton.onClick.AddListener(LoadStreetScene);
        BedRoomButton.onClick.AddListener(LoadBedRoomScene);

        // улица вообще-то :(
        ShopButton.onClick.AddListener(LoadShopScene);
        TopDownButton.onClick.AddListener(LoadTopDownScene);
    }

    // Методы для загрузки сцен
    public void LoadStreetScene()
    {
        SceneManager.LoadScene("StreetScene"); // Замените "StreetScene" на имя вашей сцены "улица"
    }

    public void LoadBedRoomScene()
    {
        SceneManager.LoadScene("BedRoomScene"); // Замените "BedRoomScene" на имя вашей сцены "спальня"
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene"); // Замените "ShopScene" на имя вашей сцены "магазин"
    }

    public void LoadTopDownScene()
    {
        SceneManager.LoadScene("TopDownScene"); // Замените "TopDownScene" на имя вашей сцены "вид сверху"
    }

}