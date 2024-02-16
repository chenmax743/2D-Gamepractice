using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }

    void Move()
    {
        float movedirection = Input.GetAxis("Horizontal");
        Vector2 player = new Vector2(movedirection * Speed, rb.velocity.y);
        rb.velocity = player;
    }
}
