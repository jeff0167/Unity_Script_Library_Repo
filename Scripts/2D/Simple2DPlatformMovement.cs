using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Simple2DPlatformMovement : MonoBehaviour
{
    float h, v;
    [SerializeField][Range(1, 100)]
    float moveSpeed;
    [SerializeField]
    float jumpForce, jumpHeight, minG, maxG;
    bool canJump = true;
    bool onGround;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        // v = Input.GetAxisRaw("Vertical"); // use vertcial for jump? use this

        //v0 = sqrt(-2 * a * s) // velocity is equal to squareroot of -2*G*H,  G=gravity,   H=height
        //float jumpHeight = 10.0f;
        //rigidbody2D.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight));

        if (Input.GetKeyDown(KeyCode.Space) && canJump) // there is a way to calculate the jump height directly so you can set the desired jumpheight instead of adding force 
        {
            //canJump = false; // could possible be circumventet by exit coll that sets canjump to false
            // rb.AddForce(Vector2.up * jumpForce); // and changing gravity
            rb.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * minG * jumpHeight));
        }

        if(!onGround && rb.velocity.y < -0.05f)
        {
            rb.gravityScale = maxG;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);     
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            onGround = true;
            rb.gravityScale = minG;
        }
    }
    void OnCollisionExit2D(Collision2D other) // if falling from a platform
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            canJump = false;
            onGround = false;
        }
    }
}
