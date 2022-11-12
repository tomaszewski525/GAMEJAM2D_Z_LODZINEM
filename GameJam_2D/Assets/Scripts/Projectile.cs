using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour
{
    int speed = 40;
    int damage = 1;
    int lifetime = 3;
    Vector3 dir;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.velocity = new Vector2(dir.x, dir.y) * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<IDamagable>() == null) { return; }
        collision.collider.GetComponent<IDamagable>().OnHit(damage);
        Destroy(gameObject);
    }
}