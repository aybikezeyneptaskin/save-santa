using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public float speed = 2;
    public float jumpHeight = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, 0);
        transform.Translate(movement * speed * Time.deltaTime);
        
        //rb.velocity = new Vector2(5,rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
        
        if(Input.GetMouseButtonDown(0) || (Input.GetKeyDown (KeyCode.Space)) /*&& onGround*/){
            rb.velocity = new Vector2(rb.velocity.y,jumpHeight);
        }
    }
    void FixedUpdate()
    {
     
    }


}