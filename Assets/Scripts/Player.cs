using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform tr;
    public Rigidbody2D rb;

    public float speed;
    public float jumpHeight2;
    public float jumpHeight1;
    public float cloudDestroyTime;
    Vector2 input;
    float jumpLimit = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision normal " + collision.contacts[0].normal.y+ collision.gameObject.tag);
        if (collision.gameObject.layer == 6 && collision.contacts[0].normal.y != -1){
            jumpLimit = 2;
        }
        else if(collision.gameObject.layer == 7 && collision.contacts[0].normal.y == 1){
            jumpLimit = 2;
            Object.Destroy(collision.gameObject, cloudDestroyTime);
        }
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (input.x < 0){
            tr.localScale = new Vector3(Mathf.Abs(tr.localScale.x)*-1,tr.localScale.y,tr.localScale.z);
        }else if (input.x > 0){
            tr.localScale = new Vector3(Mathf.Abs(tr.localScale.x),tr.localScale.y,tr.localScale.z);
        }
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
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