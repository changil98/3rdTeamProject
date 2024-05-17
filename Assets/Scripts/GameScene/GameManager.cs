using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject endPanel;
    public GameObject gordo;
    public GameObject chibi;


    static int stage = 0;

    [SerializeField] private GameObject apple;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalImage;
    [SerializeField] private Sprite speedUpImage;
    [SerializeField] private Sprite ChurnOutImage;
    [SerializeField] private Sprite AggreGateImage;

    public static int Stage
    {
        get { return stage; }
        set { stage = value; }
    }

    private void Awake()
    {
        GameManager.Instance = this;
        Time.timeScale = 1.0f;
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
        ResetGame();
        if (DataManager.instance.characterNum == 0)
        {
            gordo.SetActive(true);
            chibi.SetActive(false);
        }
        else if (DataManager.instance.characterNum == 1)
        {
            gordo.SetActive(false);
            chibi.SetActive(true);
        }
    }

    private void Update()
    {
        if(Time.timeScale <= 0f)
        {
            endPanel.SetActive(true);
        }
    }
}
