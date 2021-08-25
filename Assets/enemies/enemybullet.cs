using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float speed = 7f;
    public int damage = 10;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.tag.Equals("enemy"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
