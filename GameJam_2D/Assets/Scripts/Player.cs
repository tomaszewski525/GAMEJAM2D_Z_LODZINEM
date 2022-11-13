using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamagable
{

    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;
    bool alive = true;
    int health = 10;

    public void OnHit(int damage)
    {
        if (alive)
        {
            OnPlayerHit?.Invoke();
            health -= damage;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        StopAllCoroutines();
        print("u died");
    }
}
