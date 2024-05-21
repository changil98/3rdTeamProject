using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public Reward reward;
    public SpriteRenderer itemSpriteRenderer; // 인스펙터에서 해당 SpriteRenderer를 할당해야 합니다.


    [SerializeField] private List<Item> items = new List<Item>(); // 아이템 리스트


    private void Update()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i] == reward.GetRandomItem())
            {
                //// 스프라이트를 변경하려는 아이템의 이미지를 가져옴
                //Image image = items[i]
                //if (sprite != null)
                //{
                //    itemSpriteRenderer.sprite = sprite;
                //    itemSpriteRenderer.color = new Color(1,1,1,1);
                //}
            }
          
            
        }
    }
}
