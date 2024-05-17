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
    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private TextMeshProUGUI rewardItemDes;
    [SerializeField] private Image rewardImage;

    private Inventory inventory;
    public List<Item> items;
    private Item currentRewardItem;
    int randomIndex;

    void rewardPanelActive()
    {
        currentRewardItem = GetRandomItem();

        // 보상 팝업에 아이템 정보 표시
        rewardImage.sprite = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

        rewardPanel.SetActive(true);
    }


    // 아이템 랜덤으로 띄우기 
    public Item GetRandomItem()
    {
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
