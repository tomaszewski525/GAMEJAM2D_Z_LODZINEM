using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchStrangeIdle : Enemy
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 0;
        health = 1;
        speed = 0;
    }

    void CheckIfAttacked()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 1.7)
        {
            player.GetComponent<Player>().Die();
        }
    }
}
