using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        //up
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, velocity);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        //left
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //down
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -velocity);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        //right
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
