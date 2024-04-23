using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Complex3DMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float Speed, jumpForce, gravityPull;

    float h, v;

    bool OnGround, jump;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        OnGround = true;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        jump = Input.GetKey(KeyCode.Joystick1Button0);
        // jump = Input.GetKey(KeyCode.Space);

        if (jump && OnGround)
        {
            Debug.Log("Jumped");
            OnGround = false;
            rb.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate()
    {
        Vector2 norm = new Vector2(h, v).normalized * Speed;
        rb.velocity = new Vector3(norm.x, rb.velocity.y - gravityPull, norm.y);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }
}
