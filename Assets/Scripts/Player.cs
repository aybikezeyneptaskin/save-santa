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
    public float jumpHeight = 2;
    Vector2 input;
    int jumpLimit = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.gameObject.tag == "Ground"){
            jumpLimit = 2;
        // }
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && jumpLimit > 0){
            rb.AddForce(Vector2.up * jumpHeight*jum pLimit, ForceMode2D.Impulse);
            jumpLimit--;
        }
        
        // //rb.velocity = new Vector2(5,rb.velocity.y);
        // onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
        
        // if(Input.GetMouseButtonDown(0) || (Input.GetKeyDown (KeyCode.Space)) /*&& onGround*/){
        //     rb.velocity = new Vector2(rb.velocity.y,jumpHeight);
        // }
    }
    void FixedUpdate()
    {
     
    }


}