using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPSController : MonoBehaviour
{
    // Префаб NPC
    public GameObject npcPrefab;

    // Скрипт, отвечающий за информацию о монетах
    public NewInformation information;

    // Кнопка для продажи
    public Button sellButton;

    // Кнопка для отказа от торговли
    public Button dontTradeButton;

    // Время ожидания до удаления NPC
    public float tradeTimeout = 10f;

    // Цена товара NPC
    public int npcCoinPrice = 5;

    // Текст NPC
    public Text npcText; // Изменено имя переменной

    // Изображение NPC
    public Image npcImage;

    // Префаб изображения предмета
    public Image itemImagePrefab;

    // Массив для хранения текста, который будет говорить NPC
    public string[] npcDialogue;

    public string itemDontSell;

    public string itemSellItem;

    // Скорость печати текста
    public float typingSpeed = 0.15f;

    public Button npchelp;

    // Объект NPC
    private GameObject currentNPC;

    // Индекс текущей фразы
    private int currentDialogueIndex = 0;

    void Start()
    {
        // Настройка кнопок
        sellButton.onClick.AddListener(SellItem);
        dontTradeButton.onClick.AddListener(DontTrade);

        npchelp.onClick.AddListener(SpawnNPC);

        // Скрытие кнопок и текста по умолчанию
        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);
        itemImagePrefab.gameObject.SetActive(false);
        npcText.gameObject.SetActive(false);

        // Проверка, был ли задан скрипт с информацией
        // if (information == null)
        // {
        //     Debug.LogError("Скрипт NewInformation не был назначен. Проверьте настройки.");
        //     return;
        //// }

        //// Проверка, был ли задан текст NPC
        //if (npcText == null)
        //{
        //    Debug.LogError("Текст NPC не был назначен. Проверьте настройки.");
        //    return;
        //}

        // Изначальное значение монет (не нужно, если информация о монетах обновляется в другом месте)
        // UpdateCoinText();
    }


    // Создание нового NPC
    public void SpawnNPC()
    {

        Destroy(npchelp.gameObject);

        itemImagePrefab.gameObject.SetActive(true);

        npcText.gameObject.SetActive(true);
        // Создание экземпляра префаба
        //  currentNPC = Instantiate(npcPrefab, transform.position, Quaternion.identity);

        // Создание изображения предмета
        // Image itemImage = Instantiate(itemImagePrefab, new Vector2(currentNPC.transform.position.x, currentNPC.transform.position.y) + new Vector2(0.5f, 0), Quaternion.identity);

        // Получение изображения NPC из компонента
        // npcImage = currentNPC.GetComponent<Image>();
        // Запуск корутины для задержки появления текста и кнопок
        StartCoroutine(DelayedDialogue());

        // Запуск таймера до удаления NPC
        Invoke("DestroyNPC", tradeTimeout);
    }

    // Корутина для задержки появления текста и кнопок
    private IEnumerator DelayedDialogue()
    {
        // Ожидание 5 секунд
        yield return new WaitForSeconds(3f);

        // Включение кнопок
        sellButton.gameObject.SetActive(true);
        dontTradeButton.gameObject.SetActive(true);

        // Запуск корутины для медленной печати текста
        StartCoroutine(TypeText(npcDialogue[currentDialogueIndex]));

    }

    // Корутина для медленной печати текста
    private IEnumerator TypeText(string text)
    {
        npcText.text = "";
        foreach (char letter in text)
        {
            npcText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Переход к следующей фразе
        currentDialogueIndex++;

        if (currentDialogueIndex < npcDialogue.Length)
        {
            // Задержка перед переходом к следующей фразе
            yield return new WaitForSeconds(1f);
            StartCoroutine(TypeText(npcDialogue[currentDialogueIndex]));
        }
        else
        {
            // Все фразы были показаны, теперь показываем кнопки
            currentDialogueIndex = 0; // Сброс индекса
            sellButton.gameObject.SetActive(true);
            dontTradeButton.gameObject.SetActive(true);
        }
    }

    private void SellItem()
    {
        itemImagePrefab.gameObject.SetActive(false);
        // Увеличение количества монет
        NewInformation.Coin += npcCoinPrice;
        
        // Изменение текста NPC
        npcText.text = itemSellItem; // Изменено имя переменной

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // Задержка перед удалением NPC
        Invoke("DestroyNPC", 3f);
    }

    // Отмена торговли
    private void DontTrade()
    {
        itemImagePrefab.gameObject.SetActive(false);
        // Изменение текста NPC
        npcText.text = itemDontSell; // Изменено имя переменной

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // Задержка перед удалением NPC
        Invoke("DestroyNPC", 3f);
    }

    private void DestroyNPC()
    {
        Destroy(currentNPC);
    }

    // Обновление текста с количеством монет (не нужно, если информация о монетах обновляется в другом месте)
    // private void UpdateCoinText()
    // {
    //     // Update the coin text here using information.Coin
    // }
}
