using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flip();
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
}
