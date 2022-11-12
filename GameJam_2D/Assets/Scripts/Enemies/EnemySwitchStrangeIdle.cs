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
        SetEnemyType();
    }

    public void SetEnemyType()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(4, 6);
        enemyType = index;
    }

    void CheckIfAttacked()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= dis)
        {
            player.GetComponent<Player>().Die();
        }
    }
}
