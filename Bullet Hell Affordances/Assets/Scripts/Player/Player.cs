using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HealthBar healthbar;
    public HealthBar staminaBar;

    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float activeMoveSpeed;
    public float dashSpeed = 9f;

    public float dashLength =.05f, dashCooldown = 1f;

    public float dashCounter;
    private float dashCoolCounter;

    private bool shielded = false;

    public float maxHealth = 10f;
    public float healthLeft;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        staminaBar.SetSize(1f);
        healthbar.SetSize(1f);
        healthLeft = maxHealth;
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
                staminaBar.SetSize(0f);
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

        staminaBar.SetSize(1 - dashCoolCounter);

        if (healthLeft <= 0) {
            Killed();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Bullet")
        {
            if (!shielded)
            {                
                healthLeft = healthLeft - 1;
                healthbar.SetSize(healthLeft / maxHealth);
            }
            else
            {
                shielded = false;
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag == "Shield")
        {
            shielded = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (other.gameObject.tag == "Dash") {
            moveSpeed = moveSpeed + 2f;
            activeMoveSpeed = moveSpeed;
            dashSpeed = dashSpeed + 2f;
        }

    }

    public void Killed()
    {
        //Debug.Log("died");
        Destroy(this.gameObject);
    }
}
