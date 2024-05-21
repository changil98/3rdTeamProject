using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public static RandomItem instance;
    public Reward reward;
    public SpriteRenderer itemSpriteRenderer; // 인스펙터에서 해당 SpriteRenderer를 할당

    [SerializeField] private List<Item> items = new List<Item>(); // 아이템 리스트

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
                // 스프라이트를 변경하려는 아이템의 이미지를 가져옴
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
