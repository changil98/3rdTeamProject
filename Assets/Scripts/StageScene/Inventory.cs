using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;
    public int stageNum;
    public List<Sprite> itemSprites; // ������ �̹��� ����Ʈ
    public GameObject inventoryPanel; // �κ��丮 �г�
    public GameObject slotPrefab; // ���� ������

    private List<GameObject> slots = new List<GameObject>();


    void Start()
    {
        InitializeInventory(20); // 20ĭ¥�� �κ��丮 �ʱ�ȭ
        AddItem(0);
    }

    public void init()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ������Ʈ ����
        }

    }

    void InitializeInventory(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);
            slots.Add(slot);
        }
    }

    public void AddItem(int itemIndex)
    {
        foreach (GameObject slot in slots)
        {
            Image slotImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            if (slotImage.sprite == null)
            { 
                slotImage.sprite = itemSprites[itemIndex];
               // �������Ѱ� �ٽ� ��Ÿ���� 
                slotImage.color = new Color(1,1,1,1);
                break;
            }
        }
    }
}
