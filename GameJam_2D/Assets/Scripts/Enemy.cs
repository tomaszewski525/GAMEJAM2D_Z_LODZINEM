using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDeathAction();
    public static event EnemyDeathAction OnEnemyDeath;
    public Transform player;

    public bool alive = true;
    public int score_num;
    public int health;

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
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath();
        }
        Destroy(gameObject);
    }
}
