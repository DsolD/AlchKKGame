using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharisma : MonoBehaviour
{
    public static PlayerCharisma instance; // Статическое поле для хранения экземпляра

    public float playerCharisma = 0.9f; // Харизма игрока (10%)

    void Awake()
    {
        // Проверка, существует ли уже экземпляр
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this; // Сохраняем ссылку на текущий экземпляр
    }

    public void IncreaseCharisma()
    {
        playerCharisma += 0.01f;
        playerCharisma = Mathf.Clamp(playerCharisma, 0f, 1f); // Ограничиваем харизму в диапазоне от 0 до 1
    }
}