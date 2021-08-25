using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootenemy : MonoBehaviour
{

    private bulletscript playerbullet;

    public float firerate = 0.5f;
    float nextfire;
    public GameObject bullet;
    public Transform shootpos;


    public int turnamount = 45;
    int rotation;


    public int health = 50;
    int damage;

    void Start()
    {
        nextfire = Time.time;
    }


    void Update()
    {
        checkiftimetofire();
        print(health);
    }

    void checkiftimetofire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(bullet, new Vector3(shootpos.position.x, shootpos.position.y, 0), Quaternion.Euler(0f,0f,rotation));
            nextfire = Time.time + firerate;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
            rotation += turnamount;
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        playerbullet = hit.gameObject.GetComponent<bulletscript>();
        if(hit.collider.tag.Equals("playerbullet"))
        {
            damage = playerbullet.damage;
            losehealth(damage);
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void losehealth(int damage)
    {
        health -= damage;
    }
}
