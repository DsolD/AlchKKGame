using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{


    public GameObject Inventory;  // ������ �� ������ ���������
    public Button OpenInventoryButton;  // ������ �� ������ ���������� ���������
    private bool isOpen = false;  // ���������� ��� ������������ ��������� ���������

    void Start()
    {
        // ������������� �� ������� ������� �� ������
        OpenInventoryButton.onClick.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;  // ����������� ���������
        Inventory.SetActive(isOpen);  // ������������� ��������� ��������� � ����������� �� ���������
    }



}
