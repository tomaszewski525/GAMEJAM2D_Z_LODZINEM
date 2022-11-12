using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDeathAction(Enemy e);
    public static event EnemyDeathAction OnEnemyDeath;
    public PlayerArrowSwitch player;

    public bool alive = true;
    public int score_num;
    public int health;
    public int enemyType;

    public void CommunicateArrowSwitch()
    {

    }

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
}
