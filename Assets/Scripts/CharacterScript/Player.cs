using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 move = inputVec * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void LateUpdate()
    {
        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x > 0;
        }
        anim.SetFloat("Speed",inputVec.magnitude);
    }
}
