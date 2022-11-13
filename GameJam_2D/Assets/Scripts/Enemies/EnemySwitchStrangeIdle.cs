using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchStrangeIdle : Enemy
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 1;
        health = 1;
        speed = 0;
    }
}
