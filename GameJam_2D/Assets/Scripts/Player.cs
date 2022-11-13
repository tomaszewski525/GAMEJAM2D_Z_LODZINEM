using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamagable
{

    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;
    public delegate void PlayerDieAction();
    public static event PlayerDieAction OnPlayerDeath;
    public bool alive = true;
    int health = 5;

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
        OnPlayerDeath();
        alive = false;
    }
}
