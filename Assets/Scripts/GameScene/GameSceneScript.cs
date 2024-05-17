using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour
{
    public GameObject gordo;
    public GameObject chibi;
    public GameObject menu;

    public void PlayerReSelect()
    {
        gordo.SetActive(true);
        chibi.SetActive(false);
        menu.SetActive(false);
    }

    public void Player2ReSelect()
    {
        gordo.SetActive(false);
        chibi.SetActive(true);
        menu.SetActive(false);
    }

    public void MenuBtn()
    {
        menu.SetActive(true);
    }

    public void BackBtn()
    {
        menu.SetActive(false);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(2);
    }
}
