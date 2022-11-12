using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class EnemySwitchNormal : Enemy
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 1;
        health = 2;
        speed = 0;
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
        int index = rnd.Next(0, 2);
        enemyType = index;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            collision.collider.GetComponent<Player>().OnHit(-1);
            //animation of hitting
        }
    }
}