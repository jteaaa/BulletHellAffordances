using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBullet : MonoBehaviour
{

    public float velocity;
    private Rigidbody2D rb, targetRb;
    private Vector2 trajectory;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        trajectory = targetRb.position - rb.position;
        trajectory /= trajectory.magnitude;

        rb.velocity = velocity * trajectory;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
