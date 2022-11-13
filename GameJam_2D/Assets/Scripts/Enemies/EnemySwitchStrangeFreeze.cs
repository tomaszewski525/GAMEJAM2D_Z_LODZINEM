using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySwitchStrangeFreeze : Enemy
{
    Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score_num = 2;
        health = 3;
        speed = 4;
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
        player.gameObject.GetComponent<PlayerMovement>().ASD();
        StartCoroutine(Attack());
        Die();
    }
    
    IEnumerator Attack()
    {
        print("enter");
        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (player.transform.position - transform.position).normalized;
        Vector3 attackPosition = player.transform.position - dirToTarget * 1.3f;

        float attackSpeed = 3;
        float percent = 0;

        while (percent <= 1)
        {
            print("while");
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
           transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);
            yield return null;
        }
    }
    
}
