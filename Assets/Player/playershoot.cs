using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{

    public int extrarotation = 0;

    public Transform gunpos;

    public GameObject bullet;
    public float firerate = 2f;
    float nextfire;
    public Transform fireposition;
    float rotz;

    void Start()
    {
        nextfire = Time.time;
    }

    void Update()
    {
        checkiftimetofire();
    }

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

        transform.position = gunpos.position;
    }

    void checkiftimetofire()
    {
        if (Time.time > nextfire && Input.GetMouseButton(0))
        {
            Instantiate(bullet, new Vector3(fireposition.position.x, fireposition.position.y, 0), Quaternion.Euler(0f, 0f, rotz + extrarotation));
            nextfire = Time.time + firerate;
        }
    }
}
