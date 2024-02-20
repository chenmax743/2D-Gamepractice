using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Jumpspeed;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D Feet;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Feet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        Jump();
        CheckGrounded();
        SwitchAnimation();
    }

    void Flip() //character change 
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("Run", playerHasXAxisSpeed);
        if(playerHasXAxisSpeed)
        {
            if(rb.velocity.x>0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            
            if(rb.velocity.x<-0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    } 

    void Move() //character Move&Animation
    {
        float movedirection = Input.GetAxis("Horizontal");
        Vector2 player = new Vector2(movedirection * Speed, rb.velocity.y);
        rb.velocity = player;
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("Run", playerHasXAxisSpeed);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
                anim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, Jumpspeed);
                rb.velocity = Vector2.up * jumpVel;
            }
            
        }
    }


    void SwitchAnimation()
    {
        anim.SetBool("Idle", false);
        if(anim.GetBool("Jump"))
        {
            if (rb.velocity.y < 0.1f)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        }
        else if(isGround)
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Idle", true);
        }
    }

    void CheckGrounded()
    {
        isGround = Feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }
}
