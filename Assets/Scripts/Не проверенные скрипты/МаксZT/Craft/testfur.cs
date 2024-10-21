using UnityEngine;
using UnityEngine.UI;

public class FurScript : MonoBehaviour // Скрипт для мех в системе крафта
{
    public Information information; // Ссылка на общий скрипт с информацией о крафте
    public KotelInformation kotelInformation; // Ссылка на информации о котле
    public int firefur = 5; // Текущий градус огня (измеряется от 0 до 100)
    public int targetFire = 0; // Целевой градус огня для зелья
    public Image furImage; // Ссылка на UI изображение меха, может использоваться для визуализации
    public GameObject furObject; // Ссылка на объект меха в сцене
    public Button BlowButton; // Ссылка на кнопку "подуть"
    public ParticleSystem blowEffect; // Ссылка на эффект дуновения

    private float lastFireUpdate = 0f; // Время последнего обновления жара
    private float lastBlowTime = 0f; // Время последнего нажатия на кнопку "подуть"
    private Animator animator; // Ссылка на компонент Animator для меха

    private void Awake()
    {
        // Получаем компонент Animator с объекта меха
        animator = furObject.GetComponent<Animator>();
    }

    private void Start()
    {
        // Добавляем обработчик события нажатия на кнопку "подуть"
        BlowButton.onClick.AddListener(blowIngredient);
    }

    private void Update()
    {
        // Проверяем, зажата ли левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            // Запускаем анимацию дуя мехом
            if (!animator.GetBool("isBlowing")) // Проверяем, не активна ли анимация дуя
            {
                animator.SetBool("isBlowing", true); // Включаем анимацию
            }

            // Проверяем, прошла ли секунда с последнего дуновения
            if (Time.time - lastBlowTime >= 1f)
            {
                firefur += 5; // Увеличиваем температуру огня
                lastBlowTime = Time.time; // Обновляем время последнего дуновения
            }
        }
        else
        {
            // Если кнопка не нажата, отключаем анимацию
            if (animator.GetBool("isBlowing"))
            {
                animator.SetBool("isBlowing", false); // Отключаем анимацию
            }
        }

        // Обновляем температуру огня каждые 2 секунды
        if (Time.time - lastFireUpdate >= 2f)
        {
            firefur -= 1; // Уменьшаем температуру огня
            lastFireUpdate = Time.time; // Обновляем время последнего обновления
        }

        // Ограничиваем значение firefur в диапазоне от 0 до 100
        firefur = Mathf.Clamp(firefur, 0, 100);
    }

    public void blowIngredient()
    {
        // Включаем эффект дуновения
        blowEffect.Play();

        // Запускаем анимацию дуя мехом
        if (!animator.GetBool("isBlowing"))
        {
            animator.SetBool("isBlowing", true);
        }

        // Увеличиваем температуру огня
        firefur += 5;

        // Выключаем эффект и анимацию через секунду
        Invoke("StopBlow", 1f);
    }

    private void StopBlow()
    {
        // Выключаем эффект дуновения
        blowEffect.Stop();

        // Отключаем анимацию дуя мехом
        animator.SetBool("isBlowing", false);
    }

    public void UpdateTargetFire()
    {
        // Получаем тип зелья из скрипта KotelInformation
        string potionType = kotelInformation.GetPotionType();

        // Устанавливаем целевой градус огня в зависимости от типа зелья
        if (potionType == "Лечение")
        {
            // Для зелья лечения целевой градус от 15 до 30
            targetFire = Random.Range(15, 30);
        }
        else if (potionType == "Огнеупорность")
        {
            // Для зелья огнеупорности целевой градус от 80 до 100
            targetFire = Random.Range(80, 100);
        }
    }
}
