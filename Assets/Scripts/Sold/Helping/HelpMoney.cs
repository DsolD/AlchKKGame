using UnityEngine;
using UnityEngine.UI;

public class HelpMoney : MonoBehaviour
{
    public int Money5 = 5;   // �������� ��� ������ ������
    public int Money15 = 15;  // �������� ��� ������ ������

    public Button MinusMoneyButton;

  //  public Button Plus15MoneyButton; // ������ ��� +15
    public Button CoinZero;



    public Text AmountsMoney;
    public Text AmountsCoin;

    void Start()
    {
        // �������������� ��������� ����
        UpdateAmounts();

        // ������������� �� ������� ������� ������
        MinusMoneyButton.onClick.AddListener(MinusMoney);

  //      Plus15MoneyButton.onClick.AddListener(() => AddMoney(Money15));
        CoinZero.onClick.AddListener(CoinZerobb);

    }

    void Update()
    {
        // ��������� ��������� ���� � ������ �����
        UpdateAmounts();
    }

    void UpdateAmounts()
    {
        AmountsCoin.text = "Coins: " + Information.Coin.ToString();
        AmountsMoney.text = "Money in Help: " + Money5.ToString() + " (5), " + Money15.ToString() + " (15)";
    }

    public void MinusMoney()
    {
        Information.Coin -= Money5; // ��������� ������ �� 5
    }

    // ����� ��� ���������� �����
    public void AddMoney(int amount)
    {
        Information.Coin += amount; // ��������� ��������� ���������� �����
    }

    public void CoinZerobb()
    {
        Information.Coin = 0; // ������������� ������ � 0
    }
}
