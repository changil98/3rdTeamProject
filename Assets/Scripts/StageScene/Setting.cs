using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;

    public void ApeearSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void Exit()
    {
        settingUI.SetActive(false);
    }
}
