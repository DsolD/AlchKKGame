using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPSController : MonoBehaviour
{
    // Префаб NPC
    public GameObject npcPrefab;

    // Скрипт, отвечающий за информацию о монетах
    private NewInformation information;

    // Ссылка на PlayerCharisma
    private PlayerCharisma playerCharisma;

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

    // Ссылка на NPCCharisma
    public NPCCharisma npcCharisma;

    // Ссылка на объект предмета, который продают
 //   public GameObject itemToSell;

    void Start()
    {

        // Доступ к NewInformation через статическую переменную
        NewInformation newInformation = NewInformation.instance;
        if (newInformation == null)
        {
            Debug.LogError("NewInformation не найден!");
            return;
        }

        // Доступ к PlayerCharisma через статическую переменную
        PlayerCharisma playerCharisma = PlayerCharisma.instance;
        if (playerCharisma == null)
        {
            Debug.LogError("PlayerCharisma не найден!");
            return;
        }



        // Настройка кнопок
        sellButton.onClick.AddListener(SellItem);
        dontTradeButton.onClick.AddListener(DontTrade);

        npchelp.onClick.AddListener(SpawnNPC);

        // Скрытие кнопок и текста по умолчанию
        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);
        itemImagePrefab.gameObject.SetActive(false);
        npcText.gameObject.SetActive(false);

    }

    // Создание нового NPC
    public void SpawnNPC()
    {
        npchelp.gameObject.SetActive(false);

        // Создание объекта NPC
       // currentNPC = Instantiate(npcPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);

        // Получение компонента NPCCharisma
        npcCharisma = npcPrefab.GetComponent<NPCCharisma>();

        npcText.gameObject.SetActive(true);
        StartCoroutine(DelayedDialogue());

        // Запуск таймера до удаления NPC
        Invoke("DestroyNPC", tradeTimeout);
    }
    // Корутина для задержки появления текста и кнопок
    private IEnumerator DelayedDialogue()
    {
        // Ожидание 1.5 секунд
        yield return new WaitForSeconds(1.1f);

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

        // Рассчитываем вероятность продажи по удвоенной цене
        float sellChance = npcCharisma.CalculateSellChance(npcCoinPrice);

        // Генерируем случайное число от 0 до 100
        float randomValue = Random.Range(0f, 100f);

        // Проверяем, прошла ли продажа по удвоенной цене
        if (randomValue <= sellChance)
        {
            // Увеличиваем количество монет игрока
            NewInformation.Coin += npcCoinPrice * 2; // Исправленная строка
            // Отображаем сообщение о продаже по удвоенной цене
            npcText.text = itemSellItem;

            // Увеличиваем харизму игрока
            playerCharisma.IncreaseCharisma();

            // Удаляем NPC
            Invoke("DestroyNPC", 3f);
        }
        else
        {
            // Проверяем, успешна ли сделка
            if (npcCharisma.IsSuccessfulTrade(npcCoinPrice, npcCoinPrice))
            {
                // Увеличиваем количество монет игрока
                NewInformation.Coin += npcCoinPrice; // Исправленная строка
                // Отображаем сообщение об успешной сделке
                npcText.text = itemSellItem;

                // Увеличиваем харизму игрока
                playerCharisma.IncreaseCharisma();

                // Удаляем NPC
                Invoke("DestroyNPC", 3f);
            }
            else
            {
                // Отображаем сообщение об отказе
                npcText.text = itemSellItem;

                // Удаляем NPC
                Invoke("DestroyNPC", 3f);
            }
        }

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

    // Удаление NPC
    private void DestroyNPC()
    {
        Destroy(npcPrefab);
    }
}


