using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject gordo;
    public GameObject chibi;

    private void Start()
    {
        if (DataManager.instance.characterNum == 0)
        {
            gordo.SetActive(true);
            chibi.SetActive(false);
        }
        else if (DataManager.instance.characterNum == 1)
        {
            gordo.SetActive(false);
            chibi.SetActive(true);
        }
    }
}
