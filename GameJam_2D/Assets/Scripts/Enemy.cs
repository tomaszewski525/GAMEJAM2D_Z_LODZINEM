using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamagable
{
    public delegate void EnemyDeathAction(Enemy e);
    public static event EnemyDeathAction OnEnemyDeath;
    public PlayerArrowSwitch player;
    public bool alive = true;

    [HideInInspector]
    public int score_num;

    [HideInInspector]
    public int health;

    [HideInInspector]
    public int speed;

    [HideInInspector] 
    public int enemyType;

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
        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
    }

    void DealDamage()
    {
        
    }
}
