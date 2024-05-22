using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public static RandomItem instance;
    public Reward reward;

    [SerializeField] private List<Item> items = new List<Item>(); // ������ ����Ʈ

    public bool[] itemStates; // ������ ���¸� ������ �迭

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
  
    }


    public void InitializeItemStates()
    {
       itemStates = new bool[GameManager.Instance.itemImages.Length];
        LoadItemStates();
        UpdateItemUI();
    }


    public void GetItem()
   {
        for (int i = 0; i < items.Count; i++)
         {
            if (items[i].image.name == reward.currentRewardItem.image.name)
            {
                    Debug.Log("������ ����");

                      itemStates[i] = true;
                // �ش� �������� �̹����� ������� ����
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
                        // ���� ����
                       SaveItemStates();
             }  
          }
     }

    public void UpdateItemUI()
    {
        for(int i =0; i < items.Count; i++)
        {
            if (itemStates[i] == true)
            {
                // �ش� �������� �̹����� ������� ����
                GameManager.Instance.itemImages[i].sprite = items[i].image;
                GameManager.Instance.itemImages[i].color = Color.white;
            }
          
        }
  
    }

    // ������ ���� ����
    private void SaveItemStates()
    {

        for (int i = 0; i < itemStates.Length; i++)
        {
            PlayerPrefs.SetInt("ItemState" + i, itemStates[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    // ������ ���� �ε�
    public void LoadItemStates()
    {
        // ����� ���°� �ִٸ� �ε�
        for (int i = 0; i < itemStates.Length; i++)
        { 
            // ����� ���°� �ִٸ� �ҷ�����
            if (PlayerPrefs.HasKey("ItemState" + i))
            {
                itemStates[i] = PlayerPrefs.GetInt("ItemState" + i, 0) == 1;
            }
        }
    }

    public void OnDestroy()
    {
        // ���� �ٲ� �� ���� ����
        SaveItemStates();
    }
}


