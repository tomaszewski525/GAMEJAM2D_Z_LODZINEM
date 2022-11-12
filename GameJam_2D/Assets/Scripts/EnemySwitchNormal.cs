using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemySwitcherNormal : Enemy, IEnemy
{
    public void Start()
    {
        score_num = 2;
        health = 3;
    }
    public void Move()
    {

    }

    public void Shoot()
    {

    }

    public void SetEnemyType()
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, 2);
        enemyType = index;
    }
}
