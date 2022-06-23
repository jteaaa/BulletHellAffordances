using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{

    public float velocity;
    public Rigidbody2D rb;
    public Vector2 targetPos;
    private Vector2 startPos, trajectory;

    
    // Start is called before the first frame update
    void Start()
    {
        startPos = rb.position;
        trajectory = targetPos - startPos;
        trajectory /= trajectory.magnitude;
        rb.velocity = velocity * trajectory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
