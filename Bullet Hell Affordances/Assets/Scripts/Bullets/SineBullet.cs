using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBullet : MonoBehaviour
{

    public float velocity = 1;
    public float frequency = 1;
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

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, trajectory); //<- tbh I don't know how this portion of the code works but it does lmao
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 100000f); //<- this

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(transform.right.x, transform.right.y) * velocity * Mathf.Cos(frequency * Time.time % (2 * Mathf.PI)) + velocity * trajectory; //<- and this
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Object.Instantiate(explosion, transform.position, new Quaternion(1, 0, 0, 0));
        Destroy(this.gameObject);
    }
}

