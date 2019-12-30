using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rd;
    public int damage2D = 40;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        zombie zombie1 = hitInfo.GetComponent<zombie>();
        if (zombie1 != null)
        {
            zombie1.TakeDamage(damage2D);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    // Update is called once per frame

}
