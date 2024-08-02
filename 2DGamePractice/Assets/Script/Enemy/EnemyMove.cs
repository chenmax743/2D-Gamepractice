using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyManager
{
   public float MoveSpeed = 0;
   public float MoveDistance = 5.0f;

    private Vector3 startposition;
    private bool movingRight = true;

    public Animator aEnemyAnimation;

    void Start()
    {       
        startposition = transform.position;
        aEnemyAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        aEnemyAnimation.SetBool("Run",true);
        if(movingRight)
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1,1,1);
        }

        if(Vector3.Distance(startposition,transform.position)>=MoveDistance)
        {
            movingRight = !movingRight;
            startposition = transform.position;

           
        }

        
    }
}
