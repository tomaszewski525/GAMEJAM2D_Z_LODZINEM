using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class EnemySwitchNormal : Enemy
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 1;
        health = 2;
        speed = 5;
    }
    public void Move()
    {
        var direction = -(transform.position - player.transform.position).normalized;
        rb.MovePosition(transform.position + speed * direction * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Player>() == null) { return; }
        player.GetComponent<Player>().OnHit(-1);
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (player.transform.position - transform.position).normalized;
        Vector3 attackPosition = player.transform.position - dirToTarget * 2.0f;

        float attackSpeed = 3;
        float percent = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);
            yield return null;
        }
    }

}
