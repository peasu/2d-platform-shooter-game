using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    float x;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    bool isgrounded;
    bool facingright;

    [SerializeField] public LayerMask ground;

    public float jumpheight;
    public float speed;

    public Slider healthbar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        isgrounded = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, ground);

        if (Input.GetKeyDown(KeyCode.Space))    //
        {                                       //
            losehealth(20);                     //testing the bar
        }                                       //
    }
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (facingright == false && x > 0)
        {
            flip();
        }
        else if (facingright == true && x < 0)
        {
            flip();
        }


        if (Input.GetKeyDown(KeyCode.W) && isgrounded == true)
        {
            rb.velocity = Vector2.up * jumpheight;
        }

    }

    void flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }

    public void losehealth(int damage)
    {
        healthbar.value -= damage;
    }
}  