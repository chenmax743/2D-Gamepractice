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
    public BoxCollider2D Body;
    private bool isGround;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Feet = GetComponent<BoxCollider2D>();
        Body = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
        Jump();
        CheckGrounded();
        SwitchAnimation();
        PlayerBeAttacked();
        
    }

    void Flip() //切換腳色移動方向。 
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

    void Move() // 角色移動+跑步動畫
    {
        float movedirection = Input.GetAxis("Horizontal");
        Vector2 player = new Vector2(movedirection * Speed, rb.velocity.y);
        rb.velocity = player;
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("Run", playerHasXAxisSpeed);
    }

    void Jump() //角色跳躍
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


    void SwitchAnimation() //角色跳躍+落地
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

    void CheckGrounded()//確認是否為地面
    {
        isGround = Feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        //Debug.Log(isGround);
    }

    public void PlayerAttackAnim()
    {
        anim.SetTrigger("Attack");
    }

    public void PlayerBeAttacked()
    {

    }

    void OnTriggerEnter2D(BoxCollider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger("BeAttack");
        }
    }

    
    
}
