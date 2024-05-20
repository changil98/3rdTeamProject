using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;

    //public GameObject endPanel;
    public GameObject gordo;
    public GameObject chibi;

    public float timeRemaining = 1.0f;
    private bool timerIsRunning = false;

    static int stage = 0;

    [SerializeField] private GameObject apple;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalImage;
    [SerializeField] private Sprite speedUpImage;
    [SerializeField] private Sprite ChurnOutImage;
    [SerializeField] private Sprite AggreGateImage;
    [SerializeField] private TextMeshProUGUI timeText;

    public Reward reward;


    private List<Item> items; // ������ ����Ʈ

    public static int Stage
    {
        get { return stage; }
        set { stage = value; }
    }

    private void Awake()
    {
        //GameManager.Instance = this;
        Time.timeScale = 1.0f;
        reward.init();
    }
   

    public void ResetGame()
    {
        Rigidbody2D rb = apple.GetComponent<Rigidbody2D>();
        switch (stage)
        {
            case 0:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 0.5f;
                spriteRenderer.sprite = normalImage;
                break;
            case 1:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 1f;
                spriteRenderer.sprite = speedUpImage;
                break;
            case 2:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 0.5f;
                spriteRenderer.sprite = ChurnOutImage;
                break;
            case 3:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 1f;
                spriteRenderer.sprite = AggreGateImage;
                break;
        }
    }
    private void MakeVegetable()
    {
        Instantiate(apple);
    }

    private void Start()
    {
        timerIsRunning = true;
        InitializeItems();

        ResetGame();
        if (DataManager.instance.characterNum == 0)
        {
            Debug.Log("Ȯ��1");
            gordo.SetActive(true);
            chibi.SetActive(false);
        }
        else if (DataManager.instance.characterNum == 1)
        {
            Debug.Log("Ȯ��2");
            gordo.SetActive(false);
            chibi.SetActive(true);
        }
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


    private void Update()
    {
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0 )
            {
                timeRemaining -= Time.deltaTime;
                timeText.text = timeRemaining.ToString("N2");
            }

            else if(timeRemaining <= 0.0f)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timeText.text = timeRemaining.ToString("N2");
                // �ϴ� 0�ʰ� �Ǹ� Ŭ����ϱ� ���� �ǳ� �߰� 
                if (Reward.instance != null)
                {
                    Reward.instance.ActivePanel(); // ���� �г� Ȱ��ȭ
                }
                else
                {
                    Debug.LogError("���̷���");
                }
            }
        }
    }
}
