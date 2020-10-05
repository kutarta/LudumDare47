using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float Speed;
    public float MoveInput;

    public bool IsGrounded;
    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask ThisIsGround;
    public float JumpForce;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, ThisIsGround);

        if(IsGrounded == true && Input.GetKey(KeyCode.W) == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
    }
    private void FixedUpdate()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(MoveInput * Speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            gameObject.transform.parent = null;
        }
    }

}
