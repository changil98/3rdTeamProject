using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public static RandomItem instance;
    public Reward reward;
    public SpriteRenderer itemSpriteRenderer; // �ν����Ϳ��� �ش� SpriteRenderer�� �Ҵ�

    [SerializeField] private List<Item> items = new List<Item>(); // ������ ����Ʈ

    private void Start()
    {
        instance = this;
    }

    public void GetItem()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].image.name == reward.currentRewardItem.image.name)
            {
                // ��������Ʈ�� �����Ϸ��� �������� �̹����� ������
                Sprite sprite = items[i].image;
                if (sprite != null)
                {
                    itemSpriteRenderer.sprite = sprite;
                    itemSpriteRenderer.color = Color.white;
                }
            }  
        }
    }
}
