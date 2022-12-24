using UnityEngine;

public class Bird : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = false;
    public bool isMoving = true;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 3f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<bounds>())
        {
            dirX *= -1f;
        }
        if(collision.gameObject.tag == "Player")
        {
            isMoving = false;
            Debug.Log("collided with player");
            Debug.Log(isMoving);
            ResetGame();
        }
    }

    void FixedUpdate()
    {
        if(isMoving)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    private void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
}