using UnityEngine;
using UnityEngine.UI;

public class ButtonRepireDeleted : MonoBehaviour
{
    public Button HelpButton;
    public Image[] AllSprite; // ћассив Image, которые нужно показывать

    private void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);

        // —начала скрываем все Image
        foreach (Image image in AllSprite)
        {
            image.gameObject.SetActive(true);
        }
    }

    void Recoveries()
    {
        // ѕровер€ем, не уничтожены ли изображени€
        for (int i = 0; i < AllSprite.Length; i++)
        {
            if (AllSprite[i] == null)
            {
                // ≈сли изображение уничтожено, создаем его заново
                AllSprite[i] = Instantiate(AllSprite[0], transform);
                AllSprite[i].gameObject.SetActive(true);
            }
            else if (AllSprite[i].gameObject.activeInHierarchy == false)
            {
                // ”даление старого изображени€
                Destroy(AllSprite[i].gameObject);
                // —оздание нового изображени€
                AllSprite[i] = Instantiate(AllSprite[0], transform);
                AllSprite[i].gameObject.SetActive(true);
            }
            else
            {
                // ≈сли изображение не уничтожено, просто показываем его
                AllSprite[i].gameObject.SetActive(true);
            }
        }
    }
}

