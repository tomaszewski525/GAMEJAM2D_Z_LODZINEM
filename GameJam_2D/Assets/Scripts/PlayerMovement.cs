using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float moveForce = 10;
    float maxSpeed = 5;
    public Rigidbody2D rb;
    Vector2 movedirection;

    float moveX = 0;
    float moveY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        string g = "UDLR";
        string verticalKeys = g.Substring(0,2);
        string horizontalKeys = g.Substring(2, 2);

        if (verticalKeys == "UD")
        {
            moveY = Input.GetAxisRaw("Vertical");
        }
        else if (verticalKeys == "DU")
        {
            moveY = Input.GetAxisRaw("VerticalReversed");
        }

        if (horizontalKeys == "LR")
        {
            moveX = Input.GetAxisRaw("Horizontal");
        }
        else if (horizontalKeys == "RL")
        {
            moveX = Input.GetAxisRaw("HorizontalReversed");
        }

        movedirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {
        //rb.velocity = new Vector2(movedirection.x * moveSpeed, movedirection.y * moveSpeed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.AddForce(movedirection.normalized * moveForce);
    }
}
