using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStartScene : MonoBehaviour
{
    public void BackScene()
    {
        SceneManager.LoadScene("StartGameScene");
    }
}
