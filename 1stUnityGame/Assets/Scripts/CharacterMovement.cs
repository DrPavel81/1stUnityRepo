using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 2.5F;
    public float playerJump = 8.1F;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool ground = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(hDir, vDir, 0) * Time.deltaTime * playerSpeed;
        if (Input.GetButtonDown("Jump") && ground)
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir * playerSpeed, rb.velocity.y);

        if (jump)
        {
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jump = false;
            ground = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            ground = true;
        }
    }
}
