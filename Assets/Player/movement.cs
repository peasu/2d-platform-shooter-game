using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    float x;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private enemybullet enebull;
    bool isgrounded;

    [SerializeField] public LayerMask ground;

    public float jumpheight;
    public float speed;

    public Slider healthbar;
    public Gradient gradient;
    public Image Fill;

    int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();


        Fill.color = gradient.Evaluate(1f);

    }

    public void Update()
    {
        isgrounded = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, ground);

    }
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isgrounded == true)
        {
            rb.velocity = Vector2.up * jumpheight;
        }

    }

    public void losehealth(int damage)
    {
        healthbar.value -= damage;
        Fill.color = gradient.Evaluate(healthbar.normalizedValue);
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        enebull = hit.gameObject.GetComponent<enemybullet>();
        if (hit.collider.tag.Equals("enemybullet"))
        {
            damage = enebull.damage;
            losehealth(damage);
        }
    }
}  