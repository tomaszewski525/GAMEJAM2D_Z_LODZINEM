using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchStrangeFreeze : Enemy
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 2;
        health = 3;
        speed = 4;
        SetEnemyType();
    }
    public void Move()
    {
        var direction = -(transform.position - player.transform.position).normalized;
        rb.MovePosition(transform.position + speed * direction * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetEnemyType()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(2, 4);
        enemyType = index;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>() != null)
        {
            collision.collider.GetComponent<PlayerMovement>().Freeze();
            //animation of explozion and freeze
            Die();
        }
    }
}