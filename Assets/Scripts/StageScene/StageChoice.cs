using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChoice : MonoBehaviour
{
    
    public void NormalStage()
    {
       
       
        SceneManager.LoadScene("GameScene");
        GameManager.Stage = 0;
    }

    public void SpeedUpStage()
    {
        RandomItem.instance.LoadItemStates();
        SceneManager.LoadScene("GameScene");
        GameManager.Stage = 1;
    }

    public void ChurnOutStage()
    {
        RandomItem.instance.LoadItemStates();
        SceneManager.LoadScene("GameScene");
        GameManager.Stage = 2;
    }

    public void AggreGateStage()
    {
        RandomItem.instance.LoadItemStates();
        SceneManager.LoadScene("GameScene");
        GameManager.Stage = 3;
    }
}
