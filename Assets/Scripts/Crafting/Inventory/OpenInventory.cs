using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    public SwitchSlot SwitchSlot;
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
        SwitchSlot.SwitchCategory1();
        isOpen = !isOpen;  // ����������� ���������
        Inventory.SetActive(isOpen);  // ������������� ��������� ��������� � ����������� �� ���������
    }



}
