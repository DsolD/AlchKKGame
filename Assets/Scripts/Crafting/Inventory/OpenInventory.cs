using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    public SwitchSlot SwitchSlot;
    public Button OpenInventoryButton;
    private bool isOpen = false;
    public GameObject Iventntory;
    public Canvas CraftingCanvas;
    public float OffsetX = 6.5f;

    // Добавим переменную для хранения начальной позиции
    private Vector2 initialPositionButton;
    private Vector2 initialPositionIvent;

    void Start()
    {

        OpenInventoryButton.onClick.AddListener(ToggleInventory);

        // Запомним начальную позицию при старте
        initialPositionIvent = Iventntory.transform.position;
        initialPositionButton = OpenInventoryButton.transform.position;

    }

    private void ToggleInventory()
    {
        SwitchSlot.SwitchCategory1();
        isOpen = !isOpen;

        Iventntory.SetActive(isOpen);

        if (isOpen)
        {

            OpenInventoryButton.transform.position = new Vector2(
            OpenInventoryButton.transform.position.x + OffsetX,
            OpenInventoryButton.transform.position.y);

            Iventntory.transform.position = new Vector2(
            Iventntory.transform.position.x + OffsetX,
            Iventntory.transform.position.y);
            //OpenInventoryButton.transform.position = initialPositionButton;
            //// Возвратить "Iventntory" в исходную позицию при закрытии
            //Iventntory.transform.position = initialPositionIvent; // Используем initialPosition

        }
        else
        {

            //OpenInventoryButton.transform.position = new Vector2(
            //OpenInventoryButton.transform.position.x + OffsetX,
            //OpenInventoryButton.transform.position.y);
            //// Сдвинуть "Iventntory" вправо при открытии
            //Iventntory.transform.position = new Vector2(
            // Iventntory.transform.position.x + OffsetX,
            // Iventntory.transform.position.y);


            OpenInventoryButton.transform.position = initialPositionButton;
            // Возвратить "Iventntory" в исходную позицию при закрытии
            Iventntory.transform.position = initialPositionIvent; // Используем initialPosition
        }
    }
}
