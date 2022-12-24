using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float currentVelocity_x;
    public float currentVelocity_y;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity_x = rb.velocity.x;
        currentVelocity_y = rb.velocity.y;
    }
}
