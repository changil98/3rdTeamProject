using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSetting : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject gordo;
    [SerializeField] private GameObject chibi;

    public void ApeearSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void BackBtn()
    {
        settingUI.SetActive(false);
    }

    public void PlayerReSelect()
    {
        gordo.SetActive(true);
        chibi.SetActive(false);
        settingUI.SetActive(false);
    }

    public void Player2ReSelect()
    {
        gordo.SetActive(false);
        chibi.SetActive(true);
        settingUI.SetActive(false);
    }
}
