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

    private List<Item> items; // ������ ����Ʈ
    private Inventory inventory;
    private Item currentRewardItem; // ���� ���� ������ 
    private int randomIndex;


    private void Awake()
    { 
        if (instance == null)
            instance = this;
    }

    public void Start()
    {
        // ���� ���� �� �������� �ʱ�ȭ�ϰ� ����Ʈ�� �߰�
        InitializeItems();
    }


    void InitializeItems()
    {
        items = new List<Item>();
        // ������ ���� �� ����Ʈ�� �߰�
        Item item1 = new Item(Resources.Load<Sprite>("food_01"), "������1 ����");
        Item item2 = new Item(Resources.Load<Sprite>("food_02"), "������2 ����");
        Item item3 = new Item(Resources.Load<Sprite>("food_03"), "������3 ����");
        Item item4 = new Item(Resources.Load<Sprite>("food_04"), "������4 ����");
        Item item5 = new Item(Resources.Load<Sprite>("food_05"), "������5 ����");

        // ����Ʈ�� ������ �߰�
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
    }

    public void rewardPanelActive()
    {
        currentRewardItem = GetRandomItem();
        // ���� �˾��� ������ ���� ǥ��
        rewardImage = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

        rewardPanel.SetActive(true);
    }


    // ������ �������� ���� 
    public Item GetRandomItem()
    {
        if (items == null || items.Count == 0)
        {
            Debug.LogWarning("������ ����Ʈ�� ����ֽ��ϴ�.");
            return null;
        }

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
