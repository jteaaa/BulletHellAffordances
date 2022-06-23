using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBullet : MonoBehaviour
{

    public float velocity = 1;
    private Rigidbody2D rb;
    private Vector2 startPos, targetPos, trajectory;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPos = rb.position;
        targetPos = GameObject.Find("Player").GetComponent<Rigidbody2D>().position;

        trajectory = targetPos - startPos;
        trajectory /= trajectory.magnitude;

        rb.velocity = velocity * trajectory;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}

