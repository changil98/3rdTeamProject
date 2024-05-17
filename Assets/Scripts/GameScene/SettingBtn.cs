using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtn : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;


    public void SetActivePanel()
    {
        settingPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        settingPanel.SetActive(false);
    }

}
