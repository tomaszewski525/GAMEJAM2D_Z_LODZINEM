using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour
{
    Player player;
    float speed = 25f;
    int damage = 1;
    Vector3 dir;
    Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb.velocity = new Vector2(dir.x, dir.y) * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if((collision.collider.GetComponent<IDamagable>() != null))
        {
            collision.collider.GetComponent<IDamagable>().OnHit(damage);
        }
        Destroy(gameObject);
    }
}