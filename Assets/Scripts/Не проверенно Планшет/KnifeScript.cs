using UnityEngine;
using UnityEngine.UI;

public class KnifeScript : MonoBehaviour
{
    // Ссылка на скрипт с информацией о крафте
    public Information information;

    // Ссылка на изображение ножа
    public Image knifeImage;

    // Ссылка на объект ножа
    public GameObject knifeObject;

    // Ссылка на кнопку "Разрезать"
    public Button cutButton;

    // Ссылка на компонент Rigidbody
    public Rigidbody rb;

    // Ссылка на коллайдер ножа
    public Collider knifeCollider;

    // Слой, на котором находятся ингредиенты для резки
    public LayerMask ingredientsLayer;

    private void Awake()
    {
        // Скрываем кнопку "Разрезать" при старте
        cutButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        // Добавляем обработчик клика на кнопку "Разрезать"
        cutButton.onClick.AddListener(CutIngredient);
    }

    // Метод, вызывающийся при входе в контакт с ингредиентом
    private void OnTriggerEnter(Collider other)
    {
        // Проверка, находится ли объект на слое ингредиентов
        if (other.gameObject.layer == ingredientsLayer)
        {
            // Показываем кнопку "Разрезать"
            cutButton.gameObject.SetActive(true);
        }
    }

    // Метод, вызывающийся при выходе из контакта с ингредиентом
    private void OnTriggerExit(Collider other)
    {
        // Проверка, находится ли объект на слое ингредиентов
        if (other.gameObject.layer == ingredientsLayer)
        {
            // Скрываем кнопку "Разрезать"
            cutButton.gameObject.SetActive(false);
        }
    }

    // Метод, вызывающийся при нажатии на кнопку "Разрезать"
    public void CutIngredient()
    {
        // Скрываем кнопку "Разрезать"
        cutButton.gameObject.SetActive(false);

        // Уменьшаем количество ингредиентов на 1
        // information.total -= 1;
    }
}
