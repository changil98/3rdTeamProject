using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;

    public void ApeearSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void Exit()
    {
        settingUI.SetActive(false);
    }

    public void SoundOn()
    {
        soundOff.SetActive(true);
        soundOn.SetActive(false);
    }

    public void SoundOff()
    {
        soundOff.SetActive(false);
        soundOn.SetActive(true);
    }
}
