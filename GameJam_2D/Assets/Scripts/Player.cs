using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamagable
{
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
}
