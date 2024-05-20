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
    [SerializeField] private Image rewardImage;

    private List<Item> items; // 아이템 리스트
    public Inventory inventory;
    private Item currentRewardItem; // 현재 보상 아이템 
    private int randomIndex;

    private void Awake()
    {
        inventory.init();
    }

    public void init()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 파괴
            return;
        }

        InitializeItems();
    }


    public void ActivePanel()
    {
        currentRewardItem = GetRandomItem();
        // 보상 팝업에 아이템 정보 표시
        rewardImage.sprite = currentRewardItem.image;
        rewardImage.color = new Color(1, 1, 1, 1);
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


    // 인벤토리에 넣기 
    public void ApplyReward()
    {
        // 보상 아이템을 인벤토리에 추가
        Inventory._instance.AddItem(randomIndex);
        // 보상 팝업 창 비활성화
        rewardPanel.SetActive(false);

        SceneManager.LoadScene("StageScene");
    }
}
