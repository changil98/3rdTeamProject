using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    static int stage = 0;

    [SerializeField] private GameObject apple;

    public static int Stage
    {
        get { return stage; }
        set { stage = value; }
    }

    private void Awake()
    {
        GameManager.Instance = this;
    }

    public void ResetGame()
    {
        Rigidbody2D rb = apple.GetComponent<Rigidbody2D>();
        switch (stage)
        {
            case 0:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 0.5f;
                break;
            case 1:
                InvokeRepeating("MakeVegetable", 0, 1f);
                rb.gravityScale = 1f;
                break;
            case 2:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 0.5f;
                break;
            case 3:
                InvokeRepeating("MakeVegetable", 0, 0.7f);
                rb.gravityScale = 1f;
                break;
        }
    }

    private void Start()
    {
        ResetGame();
    }

    private void MakeVegetable()
    {
        Instantiate(apple);
    }
}
