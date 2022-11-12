using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rb;
    Vector2 movedirection;

    float moveX = 0;
    float moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveY = 1;
            //print("W");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveY = -1;
            //print("S");
        }
        else
        {
            //moveY = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveX = -1;
           // print("A");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveX = 1;
            //print("D");
        }
        else
        {
           // moveX = 0;
        }

        moveX = Input.GetAxisRaw("HorizontalReversed");
        moveY = Input.GetAxisRaw("Vertical");

        movedirection = new Vector2(moveX, moveY).normalized;

        //print(movedirection.x);
        //print(movedirection.y);

    }

    void Move()
    {
        rb.velocity = new Vector2(movedirection.x * moveSpeed, movedirection.y * moveSpeed);
        print(movedirection.x * moveSpeed);
        print(movedirection.y * moveSpeed);
    }
}
