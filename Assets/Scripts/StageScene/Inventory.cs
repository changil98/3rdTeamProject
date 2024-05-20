using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;
    public int stageNum;
    public List<Sprite> itemSprites; // 아이템 이미지 리스트
    public GameObject inventoryPanel; // 인벤토리 패널
    public GameObject slotPrefab; // 슬롯 프리팹

    private List<GameObject> slots = new List<GameObject>();


    void Start()
    {
        InitializeInventory(20); // 20칸짜리 인벤토리 초기화
        AddItem(0);
    }

    public void init()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 오브젝트 유지
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
               // 불투명한거 다시 나타나게 
                slotImage.color = new Color(1,1,1,1);
                break;
            }
        }
    }
}
