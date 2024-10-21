using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    public SwitchSlot SwitchSlot;
    public GameObject Inventory;  // Ссылка на объект инвентаря
    public Button OpenInventoryButton;  // Ссылка на кнопку открывания инвентаря
    private bool isOpen = false;  // Переменная для отслеживания состояния инвентаря

    void Start()
    {
        // Подписываемся на событие нажатия на кнопку
        OpenInventoryButton.onClick.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        SwitchSlot.SwitchCategory1();
        isOpen = !isOpen;  // Переключаем состояние
        Inventory.SetActive(isOpen);  // Устанавливаем видимость инвентаря в зависимости от состояния
    }



}
