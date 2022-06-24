using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength =.05f, dashCooldown = 1f;

    public float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (dashCoolCounter <= 0 && dashCounter <= 0) {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0) {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0) {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0) {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
