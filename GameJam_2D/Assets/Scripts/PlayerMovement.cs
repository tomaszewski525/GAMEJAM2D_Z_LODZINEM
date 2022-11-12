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
    private Animator m_animator;
    private Vector2 movedirection;
    public string movementKeyPattern = "UDLR";
    private Vector2 vectorUp = Vector2.up;
    private Vector2 mousePos;

    private float moveX = 0;
    private float moveY = 0;
    bool freeze = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }
    public IEnumerator Freeze()
    {
        freeze = true;
        //yield return new WaitForSeconds(3.0f);
        freeze = false;
        yield return null;
    }
    void Update()
    {
        ProcessInput();
        //print(freeze);
    }

    private void FixedUpdate()
    {
        Move();
    }


    void ProcessInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
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

        moveY = Input.GetAxisRaw(verticalKeys);
        moveX = Input.GetAxisRaw(horizontalKeys);
       
        if (m_animator)
        {
            // UP
            if(angle > 45 && angle <= 135 && moveY == 0)
            {
                //m_animator.SetTrigger("IdleBackward");
                m_animator.Play("anim_idle_backward");
                //print("IdleBackward");
            }
            else if (angle > 45 && angle <= 135 && moveY != 0)
            {
                m_animator.Play("anim_run_backward");
                //m_animator.SetTrigger("GoBackward");
                //print("GOBackward");
            }


            // RIGHT
            else if (angle > -45 && angle < 45 && moveX == 0)
            {
                // m_animator.SetTrigger("IdleRight");
                m_animator.Play("anim_idle_right");
                //print("IdleRight");
            }
            else if (angle > -45 && angle < 45 && moveX != 0)
            {
                // m_animator.SetTrigger("GoRight");
                m_animator.Play("anim_run_right");
                //print("GoRight");
            }




            // FORWARD
            else if (angle >= -135 && angle < -45 && moveY == 0)
            {
                //m_animator.SetTrigger("IdleForward 0");
                m_animator.Play("anim_idle");
                //print("IdleForward 0");
            }
            else if (angle > -135 && angle < -45 && moveY != 0)
            {
                //m_animator.SetTrigger("GoForward");
                m_animator.Play("anim_run_forward");
                //print("GoForward");
            }



            // LEFT
            else if (angle > -135 && angle > 135 && moveX == 0)
            {
                //m_animator.SetTrigger("IdleLeft");
                m_animator.Play("anim_idle_left");
                //print("IdleLeft");
            }
            else if (angle > -135 && angle > 135 && moveX != 0)
            {
                //m_animator.SetTrigger("GoLeft");
                m_animator.Play("anim_run_left");
                //print("GoLeft");
            }
            else
            {
                m_animator.Play("anim_idle");
                //m_animator.SetTrigger("IdleForward 0");
                //print("IdleForward 0");

            }


         
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
