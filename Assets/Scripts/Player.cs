using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public float speed;
    public float jumpHeight2;
    public float jumpHeight1;
    Vector2 input;
    float jumpLimit = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collision normal " + collision.contacts[0].normal.y);
            if (collision.contacts[0].normal.y != -1)
            {
                jumpLimit = 2;
            }
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && jumpLimit == 2){
            rb.AddForce(Vector2.up * jumpHeight2, ForceMode2D.Impulse);
            jumpLimit--;
        }else if(Input.GetKeyDown(KeyCode.Space) && jumpLimit == 1){
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(Vector2.up * jumpHeight1, ForceMode2D.Impulse);
            jumpLimit--;
        }

    }
    void FixedUpdate()
    {
     
    }


}