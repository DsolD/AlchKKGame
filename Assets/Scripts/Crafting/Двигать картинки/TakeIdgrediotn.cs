using UnityEngine;
using UnityEngine.UI; // Подключаем библиотеку UI

public class TakeIdgrediotn : MonoBehaviour
{
    public Image targetImage; // Объект Image, в который будем загружать картинку



    void Start()
    {
        // Проверяем, есть ли Image в сцене
        if (targetImage != null)
        {


        }
        else
        {
            Debug.LogError("Не найден Image на сцене!");
        }
    }
}