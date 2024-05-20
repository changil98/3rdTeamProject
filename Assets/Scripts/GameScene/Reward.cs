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

    private List<Item> items; // ������ ����Ʈ
    public Inventory inventory;
    private Item currentRewardItem; // ���� ���� ������ 
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
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ������Ʈ ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� �ı�
            return;
        }

        InitializeItems();
    }


    public void ActivePanel()
    {
        currentRewardItem = GetRandomItem();
        // ���� �˾��� ������ ���� ǥ��
        rewardImage.sprite = currentRewardItem.image;
        rewardImage.color = new Color(1, 1, 1, 1);
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


    // �κ��丮�� �ֱ� 
    public void ApplyReward()
    {
        // ���� �������� �κ��丮�� �߰�
        Inventory._instance.AddItem(randomIndex);
        // ���� �˾� â ��Ȱ��ȭ
        rewardPanel.SetActive(false);

        SceneManager.LoadScene("StageScene");
    }
}
