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
    }

    public void ActivePanel()
    {
            rewardPanel.SetActive(true);
        
    }

    public void rewardPanelActive()
    {
        currentRewardItem = GetRandomItem();
        // ���� �˾��� ������ ���� ǥ��
        rewardImage = currentRewardItem.image;
        rewardItemDes.text = currentRewardItem.description;

       
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
