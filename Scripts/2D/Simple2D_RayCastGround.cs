using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class Simple2D_RayCastGround : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed, jumpForce;

    float h;
    Transform ground;

    [SerializeField]
    LayerMask groundLayer;

    bool WillJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = transform.GetChild(0).transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            WillJump = true;
        }
        else WillJump = false;
    }

    bool IsGrounded() // use a child object with a collider to measure where the boxcollider should be as well as size, should be disabled is only for reference!  dist and dir doesn't matter so set dist to 0
    {
        return Physics2D.BoxCast(ground.position, new Vector2(1, 0.1f), 0f, Vector2.down, 0f, groundLayer); // start pos, size off box, angle, dir, distance, layer    
    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (WillJump && IsGrounded())
        {
            Jump();
        }

        Vector2 moveVel = new Vector2(h * speed, rb.velocity.y - 9.81f);
        rb.velocity = Vector2.ClampMagnitude(moveVel, 10000);
    }

    void Jump()
    {
        rb.AddForce(Vector2.ClampMagnitude(new Vector2(rb.velocity.x, jumpForce * 10), 10000));
    }
}
