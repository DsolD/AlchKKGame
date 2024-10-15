using UnityEngine;
using UnityEngine.UI;

public class HelpMoney : MonoBehaviour
{
    public int Money5 = 5;   // Значение для первой кнопки
    public int Money15 = 15;  // Значение для второй кнопки

    public Button MinusMoneyButton;

  //  public Button Plus15MoneyButton; // Кнопка для +15
    public Button CoinZero;



    public Text AmountsMoney;
    public Text AmountsCoin;

    void Start()
    {
        // Инициализируем текстовые поля
        UpdateAmounts();

        // Подписываемся на события нажатия кнопок
        MinusMoneyButton.onClick.AddListener(MinusMoney);

  //      Plus15MoneyButton.onClick.AddListener(() => AddMoney(Money15));
        CoinZero.onClick.AddListener(CoinZerobb);

    }

    void Update()
    {
        // Обновляем текстовые поля в каждом кадре
        UpdateAmounts();
    }

    void UpdateAmounts()
    {
        AmountsCoin.text = "Coins: " + Information.Coin.ToString();
        AmountsMoney.text = "Money in Help: " + Money5.ToString() + " (5), " + Money15.ToString() + " (15)";
    }

    public void MinusMoney()
    {
        Information.Coin -= Money5; // Уменьшаем монеты на 5
    }

    // Метод для добавления монет
    public void AddMoney(int amount)
    {
        Information.Coin += amount; // Добавляем указанное количество монет
    }

    public void CoinZerobb()
    {
        Information.Coin = 0; // Устанавливаем монеты в 0
    }
}
