using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Chibi"))
        {
            Time.timeScale = 0f;
            DataManager.instance.characterNum = 1;
        } 
        if (collision.gameObject.CompareTag("Gordo"))
        {
            Time.timeScale = 0f;
            DataManager.instance.characterNum = 0;
        }
    }

    private void Start()
    {
        float x = Random.Range(-2.8f, 2.5f);
        float y = 5f;

        transform.position = new Vector3(x, y, 0); 
    }
}
