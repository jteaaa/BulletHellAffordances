using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{

    public float velocity = 1;
    public Explosion explosion;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        Object.Instantiate(explosion, transform.position, new Quaternion(1, 0, 0, 0));
        Destroy(this.gameObject);
    }
}
