using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float agroRange;
    public float speed;
    public Transform target;
    public int health = 100;
    public GameObject deathEffeect;
    private bool move = true;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
      
        float distToPlayer = Vector2.Distance(transform.position, target.position);
        if (distToPlayer < agroRange)
        {
            ChasePlaer();
        }
        else
        {
            StopChasingPlayer();
        }
        animator.SetFloat("speed", speed);
    }

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
    }

    void ChasePlaer()
    {
       
        if (transform.position.x < target.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-1, 1);

        }
        else if(transform.position.x > target.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(1, 1);

        }
    }
    


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffeect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
}
