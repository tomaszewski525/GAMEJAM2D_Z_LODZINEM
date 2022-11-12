using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float moveForce = 2;
    public float maxSpeed = 5;
    private float angle;

    private Rigidbody2D rb;
    PlayerArrowSwitch player;
    public Animator m_animator;
    private const string basicKeyPattern = "WSAD";
    public string movementKeyPattern;
    //private Dictionary<string, Vector2> a = { }; // up -> 0 -> "DULR"[0] -> D -> vector2(0,-1)
    private Vector2 vectorUp = Vector2.up;
    private Vector2 mousePos;
    private Vector2 currentDirection = Vector2.right;

    private float moveX = 0;
    private float moveY = 0;
    bool freeze = false;
    
    Vector2 Function(char letter)
    {
        int index = basicKeyPattern.IndexOf(letter);
        char l = movementKeyPattern[index];
        if (l == 'S')
        {
            return Vector2.down;
        }
        else if (l == 'W')
        {
            return Vector2.up;
        }
        else if (l == 'A')
        {
            return Vector2.left;
        }
        else if (l == 'D')
        {
            return Vector2.right;
        }
        else return Vector2.zero;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        player = GetComponent<PlayerArrowSwitch>();
        movementKeyPattern = player.currentArrows;
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

    Vector2 GetInput()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir = Function('W');

        }
        else if (Input.GetKey(KeyCode.S)){
            dir = Function('S');
        }
        else if (Input.GetKey(KeyCode.A)){
            dir = Function('A');
        }
        else if (Input.GetKey(KeyCode.D)){
            dir = Function('D');
        }
        return dir;
    }

    void ProcessInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Vector2 dire = GetInput();
        Move(dire);
        print(dire);
        moveY = dire.y;
        moveX = dire.x;
            if (m_animator)
            {
                // UP
                if (angle >= 45 && angle <= 135 && moveY == 0)
                {
                    //m_animator.SetTrigger("IdleBackward");
                    m_animator.Play("anim_idle_backward");
                    //print("IdleBackward");
                }
                else if (angle >= 45 && angle <= 135 && moveY != 0)
                {
                    m_animator.Play("anim_run_backward");
                    //m_animator.SetTrigger("GoBackward");
                    //print("GOBackward");
                }


                // RIGHT
                else if (angle >= -45 && angle < 45 && moveX == 0)
                {
                    // m_animator.SetTrigger("IdleRight");
                    m_animator.Play("anim_idle_right");
                    //print("IdleRight");
                }
                else if (angle >= -45 && angle < 45 && moveX != 0)
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
                else if (angle >= -135 && angle < -45 && moveY != 0)
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
    }
    

    void Move(Vector2 movedirection)
    {
        if (!freeze)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(movedirection.normalized * moveForce);
        }
    }
}
