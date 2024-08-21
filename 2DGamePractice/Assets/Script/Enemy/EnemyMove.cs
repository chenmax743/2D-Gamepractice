using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyManager
{
   public float MoveSpeed = 0;
   public float MoveDistance = 5.0f;

    private Vector3 startposition;
    private bool movingRight = false;

    public Animator aEnemyAnimation;

    void Start()
    {       
        startposition = transform.position;
        aEnemyAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        aEnemyAnimation.SetBool("Run",true);
         if (movingRight)
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            if (transform.position.x >= startposition.x + MoveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
            if (transform.position.x <= startposition.x - MoveDistance)
            {
                movingRight = true;
                Flip();
            }
        }

        
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x*=-1;
        transform.localScale=localScale;
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            movingRight =!movingRight;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            aEnemyAnimation.SetBool("Attack",true);
        }
    }
}
