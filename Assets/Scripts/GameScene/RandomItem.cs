using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    public Reward reward;
    public SpriteRenderer itemSpriteRenderer; // �ν����Ϳ��� �ش� SpriteRenderer�� �Ҵ��ؾ� �մϴ�.


    [SerializeField] private List<Item> items = new List<Item>(); // ������ ����Ʈ


    private void Update()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i] == reward.GetRandomItem())
            {
                //// ��������Ʈ�� �����Ϸ��� �������� �̹����� ������
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
