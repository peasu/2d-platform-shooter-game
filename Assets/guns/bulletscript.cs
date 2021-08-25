using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed = 7f;
    public int damage = 20;
    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        Destroy(gameObject);
    }
}