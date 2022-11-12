using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float moveForce = 10;
    public float maxSpeed = 5;

    private Rigidbody2D rb;
    private Vector2 movedirection;
    public string movementKeyPattern = "UDLR";

    private float moveX = 0;
    private float moveY = 0;
    bool freeze = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public IEnumerator Freeze()
    {
        freeze = true;
        yield return new WaitForSeconds(3.0f);
        freeze = false;
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
        string verticalKeys = movementKeyPattern.Substring(0,2);
        string horizontalKeys = movementKeyPattern.Substring(2, 2);

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
        if (!freeze)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(movedirection.normalized * moveForce);
        }
    }
}
