using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() == null) { return; }
        Enemy e = collision.collider.GetComponent<Enemy>();
        e.OnHit(3);
    }
}
