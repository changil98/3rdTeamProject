using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject characterSelect;
    private void Awake()
    {

    }
    public void GameStartBtn()
    {
        startUI.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void Select()
    {
        SceneManager.LoadScene(1);
    }
}
