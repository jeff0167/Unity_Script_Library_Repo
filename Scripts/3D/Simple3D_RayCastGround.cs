using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Simple3D_RayCastGround : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float Speed, jumpForce, gravityPull;

    float h, v;

    bool jump;

    Transform ground;

    [SerializeField]
    LayerMask groundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ground = transform.GetChild(0).transform;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        jump = Input.GetKey(KeyCode.Joystick1Button0);
       // jump = Input.GetKey(KeyCode.Space);
    }

    bool IsGrounded() 
    {
        RaycastHit hit;

        Vector3 p1 = transform.position + ground.position;
        return Physics.SphereCast(p1, 0.5f, transform.up * -1, out hit, 1f);
    }

    private void FixedUpdate()
    {
        Vector2 norm = new Vector2(h, v).normalized * Speed;
        rb.velocity = new Vector3(norm.x, rb.velocity.y - gravityPull, norm.y);

        if (jump && IsGrounded())
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
}
