using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchStrange : Enemy, IEnemy
{
    public void Start()
    {
        score_num = 4;
        health = 2;
        SetEnemyType();
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
        int index = rnd.Next(2, 6);
        enemyType = index;
    }
}
