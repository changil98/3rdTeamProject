using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject exitBtn;

    //[SerializeField] private Text money;


    public void SetActivePanel()
    {
        shopPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        shopPanel.SetActive(false);
    }

}
