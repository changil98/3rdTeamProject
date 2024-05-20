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
    private int randomIndex;


    private void Awake()
    { 
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
    }

    public void ActivePanel()
    {
            rewardPanel.SetActive(true);
        
    }

    public void rewardPanelActive()
    {
        currentRewardItem = GetRandomItem();
        // 보상 팝업에 아이템 정보 표시
        rewardImage = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

       
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
