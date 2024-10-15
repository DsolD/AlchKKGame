using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPSController : MonoBehaviour
{
    // Префаб NPC
    public GameObject npcPrefab;

    // Скрипт, отвечающий за информацию о монетах
    public Information information;

    // Кнопка для продажи
    public Button sellButton;

    // Кнопка для отказа от торговли
    public Button dontTradeButton;

    // Время ожидания до удаления NPC
    public float tradeTimeout = 5f;

    // Цена товара NPC
    public int npcCoinPrice = 5;

   // public Text CoinText;

    public Image npcImage;

    public Image itemImagePrefab;

    public Text npctext;

    // Объект NPC
    private GameObject currentNPC;

    void Start()
    {
        // Настройка кнопок
        sellButton.onClick.AddListener(SellItem);
        dontTradeButton.onClick.AddListener(DontTrade);

        // Изначальное значение монет
  //      UpdateCoinText();

        UpdateNPCtext();
    }

    // Создание нового NPC
    public void SpawnNPC()
    {
        // Создание экземпляра префаба
        currentNPC = Instantiate(npcPrefab, transform.position, Quaternion.identity);

        Image itemImage = Instantiate(itemImagePrefab, new Vector2(currentNPC.transform.position.x, currentNPC.transform.position.y) + new Vector2(0.5f, 0),Quaternion.identity);

        npcImage = currentNPC.GetComponent<Image>();

        // Запуск корутины для задержки появления текста и кнопок
        StartCoroutine(DelayedDialogue());

        // Запуск таймера до удаления NPC
        Invoke("DestroyNPC", tradeTimeout);
    }

    // Корутина для задержки появления текста и кнопок
    private IEnumerator DelayedDialogue()
    {
        // Ожидание 5 секунд
        yield return new WaitForSeconds(5f);

        // Включение кнопок
        sellButton.gameObject.SetActive(true);
        dontTradeButton.gameObject.SetActive(true);

        // Включение текста NPC (добавьте Text-компонент к NPC-префабу и получите его ссылку здесь)
        // currentNPC.GetComponent<Text>().gameObject.SetActive(true); 
    }


    private void SellItem()
    {
        // Увеличение количества монет (берем из information.coin)
        Information.Coin += npcCoinPrice;

        // Обновление текста монет
  //      UpdateCoinText();

        // Изменение текста NPC
        npctext.text = "Спасибо большое!";

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // Задержка перед удалением NPC
        Invoke("DestroyNPC", 3f); // Добавьте задержку перед удалением (1 секунда)
    }

    // Отмена торговли
    private void DontTrade()
    {
        // Изменение текста NPC
        npctext.text = "Ладно, загляну позже.";

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // Задержка перед удалением NPC
        Invoke("DestroyNPC", 3f); // Добавьте задержку перед удалением (1 секунда)
    }

    // Обновление текста монет НАДО УБРАТЬ НАДО БУРАТЬ УНАДЖО УБРАТЬ хотя хз
    //private void UpdateCoinText()
    //{
    //    // Отображение количества монет в текстовом поле (берем из information.coin)
    //    CoinText.text = "У меня сейчас " + Information.Coin + " Золотых";
    //}

    private void UpdateNPCtext()
    {
        // Отображение количества монет в текстовом поле (берем из information.coin)
        npctext.text = "Я хочу купить у вас клубнику за " + npcCoinPrice + " Золотых";
    }

    // Удаление NPC
    private void DestroyNPC()
    {
        // Отключение кнопок


        // Удаление объекта NPC
        Destroy(npcPrefab);
    }



}