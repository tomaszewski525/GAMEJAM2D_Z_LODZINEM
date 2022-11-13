using Newtonsoft.Json.Bson;
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
        speed = 10;
    }
    public void Move()
    {
        var direction = -(transform.position - player.transform.position).normalized;
        rb.MovePosition(transform.position + speed * direction * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
        CheckIfAttacked();
    }

    void CheckIfAttacked()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 1.7)
        {
            player.GetComponent<Player>().OnHit(-1);
        }
    }
}
