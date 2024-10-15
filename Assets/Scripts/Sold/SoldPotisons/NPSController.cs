using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPSController : MonoBehaviour
{
    // ������ NPC
    public GameObject npcPrefab;

    // ������, ���������� �� ���������� � �������
    public Information information;

    // ������ ��� �������
    public Button sellButton;

    // ������ ��� ������ �� ��������
    public Button dontTradeButton;

    // ����� �������� �� �������� NPC
    public float tradeTimeout = 5f;

    // ���� ������ NPC
    public int npcCoinPrice = 5;

   // public Text CoinText;

    public Image npcImage;

    public Image itemImagePrefab;

    public Text npctext;

    // ������ NPC
    private GameObject currentNPC;

    void Start()
    {
        // ��������� ������
        sellButton.onClick.AddListener(SellItem);
        dontTradeButton.onClick.AddListener(DontTrade);

        // ����������� �������� �����
  //      UpdateCoinText();

        UpdateNPCtext();
    }

    // �������� ������ NPC
    public void SpawnNPC()
    {
        // �������� ���������� �������
        currentNPC = Instantiate(npcPrefab, transform.position, Quaternion.identity);

        Image itemImage = Instantiate(itemImagePrefab, new Vector2(currentNPC.transform.position.x, currentNPC.transform.position.y) + new Vector2(0.5f, 0),Quaternion.identity);

        npcImage = currentNPC.GetComponent<Image>();

        // ������ �������� ��� �������� ��������� ������ � ������
        StartCoroutine(DelayedDialogue());

        // ������ ������� �� �������� NPC
        Invoke("DestroyNPC", tradeTimeout);
    }

    // �������� ��� �������� ��������� ������ � ������
    private IEnumerator DelayedDialogue()
    {
        // �������� 5 ������
        yield return new WaitForSeconds(5f);

        // ��������� ������
        sellButton.gameObject.SetActive(true);
        dontTradeButton.gameObject.SetActive(true);

        // ��������� ������ NPC (�������� Text-��������� � NPC-������� � �������� ��� ������ �����)
        // currentNPC.GetComponent<Text>().gameObject.SetActive(true); 
    }


    private void SellItem()
    {
        // ���������� ���������� ����� (����� �� information.coin)
        Information.Coin += npcCoinPrice;

        // ���������� ������ �����
  //      UpdateCoinText();

        // ��������� ������ NPC
        npctext.text = "������� �������!";

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // �������� ����� ��������� NPC
        Invoke("DestroyNPC", 3f); // �������� �������� ����� ��������� (1 �������)
    }

    // ������ ��������
    private void DontTrade()
    {
        // ��������� ������ NPC
        npctext.text = "�����, ������� �����.";

        sellButton.gameObject.SetActive(false);
        dontTradeButton.gameObject.SetActive(false);

        // �������� ����� ��������� NPC
        Invoke("DestroyNPC", 3f); // �������� �������� ����� ��������� (1 �������)
    }

    // ���������� ������ ����� ���� ������ ���� ������ ������ ������ ���� ��
    //private void UpdateCoinText()
    //{
    //    // ����������� ���������� ����� � ��������� ���� (����� �� information.coin)
    //    CoinText.text = "� ���� ������ " + Information.Coin + " �������";
    //}

    private void UpdateNPCtext()
    {
        // ����������� ���������� ����� � ��������� ���� (����� �� information.coin)
        npctext.text = "� ���� ������ � ��� �������� �� " + npcCoinPrice + " �������";
    }

    // �������� NPC
    private void DestroyNPC()
    {
        // ���������� ������


        // �������� ������� NPC
        Destroy(npcPrefab);
    }



}