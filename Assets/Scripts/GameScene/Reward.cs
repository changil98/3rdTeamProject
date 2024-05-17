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

        // ���� �˾��� ������ ���� ǥ��
        rewardImage.sprite = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

        rewardPanel.SetActive(true);
    }


    // ������ �������� ���� 
    public Item GetRandomItem()
    {
        randomIndex = Random.Range(0, items.Count);
        return items[randomIndex];
    }


    // �κ��丮�� �ֱ� 
    public void ApplyReward()
    {
        // ���� �������� �κ��丮�� �߰�
        inventory.AddItem(randomIndex);
        // ���� �˾� â ��Ȱ��ȭ
        rewardPanel.SetActive(false);

        SceneManager.LoadScene("StageScene");
    }
}
