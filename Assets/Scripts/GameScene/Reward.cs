using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Reward : MonoBehaviour
{
    public static Reward instance;


    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private TextMeshProUGUI rewardItemDes;
    [SerializeField] private Sprite rewardImage;

    private List<Item> items; // 아이템 리스트
    private Inventory inventory;
    private Item currentRewardItem; // 현재 보상 아이템 
    int randomIndex;


    private void Awake()
    {
        rewardPanel.SetActive(false);
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        // 게임 시작 시 아이템을 초기화하고 리스트에 추가
        InitializeItems();
    }


    void InitializeItems()
    {
        items = new List<Item>();
        // 아이템 생성 및 리스트에 추가
        Item item1 = new Item(Resources.Load<Sprite>("food_01"), "아이템1 설명");
        Item item2 = new Item(Resources.Load<Sprite>("food_02"), "아이템2 설명");
        Item item3 = new Item(Resources.Load<Sprite>("food_03"), "아이템3 설명");
        Item item4 = new Item(Resources.Load<Sprite>("food_04"), "아이템4 설명");
        Item item5 = new Item(Resources.Load<Sprite>("food_05"), "아이템5 설명");

        // 리스트에 아이템 추가
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }

    public void rewardPanelActive()
    {
        currentRewardItem = GetRandomItem();
        // 보상 팝업에 아이템 정보 표시
        rewardImage = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

        rewardPanel.SetActive(true);
    }


    // 아이템 랜덤으로 띄우기 
    public Item GetRandomItem()
    {
        if (items == null || items.Count == 0)
        {
            Debug.LogWarning("아이템 리스트가 비어있습니다.");
            return null;
        }

        randomIndex = Random.Range(0, items.Count);
        return items[randomIndex];
    }


    // 인벤토리에 넣기 
    public void ApplyReward()
    {
        // 보상 아이템을 인벤토리에 추가
        inventory.AddItem(randomIndex);
        // 보상 팝업 창 비활성화
        rewardPanel.SetActive(false);

        SceneManager.LoadScene("StageScene");
    }
}
