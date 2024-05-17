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
    }

    private void Start()
    {
        float x = Random.Range(-2.8f, 2.5f);
        float y = 5f;

        transform.position = new Vector3(x, y, 0); 
    }
}
