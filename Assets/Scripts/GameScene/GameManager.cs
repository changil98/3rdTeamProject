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


    private List<Item> items; // 아이템 리스트

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
            Debug.Log("확인1");
            gordo.SetActive(true);
            chibi.SetActive(false);
        }
        else if (DataManager.instance.characterNum == 1)
        {
            Debug.Log("확인2");
            gordo.SetActive(false);
            chibi.SetActive(true);
        }
    }



    void InitializeItems()
    {
        items = new List<Item>();
        // 아이템 생성 및 리스트에 추가
        Item item1 = new Item(Resources.Load<Sprite>("food_01"), "아이템1 설명");
        Item item2 = new Item(Resources.Load<Sprite>("food_02"), "아이템2 설명");
        Item item3 = new Item(Resources.Load<Sprite>("food_03"), "아이템3 설명");
        Item item4 = new Item(Resources.Load<Sprite>("food_04"), "아이템4 설명");
        Item item5 = new Item(Resources.Load<Sprite>("food_05"), "아이템5 설명");

        // 리스트에 아이템 추가
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
                // 일단 0초가 되면 클리어니까 보상 판넬 뜨게 
                if (Reward.instance != null)
                {
                    Reward.instance.ActivePanel(); // 보상 패널 활성화
                }
                else
                {
                    Debug.LogError("와이러노");
                }
            }
        }
    }
}
