using UnityEngine;
using UnityEngine.UI;

public class PreFabNew : MonoBehaviour
{
    public Button HelpButton;
    public GameObject[] AllPrefabs; // ������ ��������, ������� ����� ����������
    public Transform parentTransform; // ��������� ������������� ������� ��� ��������� �����������

    private GameObject[] prefabInstances; // ������ ��� �������� ��������� ����������� ��������

    public Vector2 canvasSize; // ������ Canvas
    public Vector2 prefabSize = new Vector2(100, 150); // ������ ��������

    private void Start()
    {
        HelpButton.onClick.AddListener(Recoveries);

        // �������������� ������ prefabInstances
        prefabInstances = new GameObject[AllPrefabs.Length];
        for (int i = 0; i < AllPrefabs.Length; i++)
        {
            prefabInstances[i] = null;
        }
    }

    void Recoveries()
    {
        // ���������, �� ���������� �� �������
        for (int i = 0; i < AllPrefabs.Length; i++)
        {
            if (prefabInstances[i] == null)
            {
                // ���� ������ ���������, ������� ��� ������
                prefabInstances[i] = CreatePrefabInstance(AllPrefabs[i]);
            }
            else
            {
                // ���� ������ �� ���������, ������ ���������� ���
                prefabInstances[i].SetActive(true);
            }
        }
    }

    // ������� ��� �������� ������ ���������� �������
    private GameObject CreatePrefabInstance(GameObject prefab)
    {
        // ���������� ��������� ������� �� Canvas
        Vector2 randomPosition = new Vector2(
            Random.Range(-canvasSize.x / 2 + prefabSize.x / 2, canvasSize.x / 2 - prefabSize.x / 2),
            Random.Range(-canvasSize.y / 2 + prefabSize.y / 2, canvasSize.y / 2 - prefabSize.y / 2)
        );

        // ������� ����� ��������� �������
        GameObject newPrefabInstance = Instantiate(prefab, parentTransform);
        newPrefabInstance.transform.localPosition = randomPosition; // ������������� ��������� �������

        // ������������� ������ ������� (���� �����)
        RectTransform rectTransform = newPrefabInstance.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = prefabSize;
        }

        return newPrefabInstance;
    }
}

