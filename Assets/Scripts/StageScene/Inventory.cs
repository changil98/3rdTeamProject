using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;
    public int stageNum;
    
    public GameObject inventoryPanel; // �κ��丮 �г�
    public GameObject slotPrefab; // ���� ����


    private List<GameObject> slots = new List<GameObject>(); // ������ ������ ������ ����Ʈ
    public List<Sprite> itemSprites; // ������ �̹��� ����Ʈ


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
        else
        {
            Destroy(gameObject);
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

    public void AddItem(int index)
    {
        Debug.Log(index);
        Debug.Log(slots.Count);
        foreach (GameObject slot in slots)
        {
            Image slotImage = slot.transform.Find("ItemImage").GetComponent<Image>();
            if (slotImage.sprite == null)
            {
                Debug.Log("Item added to slot: " + index);
                slotImage.sprite = itemSprites[index];
                if (itemSprites[index] != null)
                {
                    Debug.Log("����" );
                }
               // �������Ѱ� �ٽ� ��Ÿ���� 
                slotImage.color = new Color(1,1,1,1);
               
                break;
            }
          
        }
    }
}
