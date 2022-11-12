using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamagable
{
    public Enemy[] enemies;
    bool alive = true;
    int health = 10;

    public void OnHit(int damage)
    {
        if (alive)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        alive = false;
        print("u died");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, 3);
            enemies[index].Spawn();
        }
    }
}
