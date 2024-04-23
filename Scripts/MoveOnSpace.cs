using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnSpace : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    GameObject Star;

    [SerializeField]
    float JumpSpeed, starAmount;
    bool onGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("StarSpawner", 0, 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.velocity = Vector3.right * JumpSpeed;
            JumpSpeed *= -1;
        }
    }

    void StarSpawner()
    {
        for (int i = 0; i < starAmount; i++)
        {
            GameObject g = Instantiate(Star, new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 10f)), Star.transform.rotation);
            float index = Random.Range(0.5f, 1.1f);
            g.transform.localScale = new Vector3(index, index, index);
        }
    }

    void OnCollisionEnter2D(Collision2D other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
            onGround = true;
        }
        else
        {
            //reload lvl
        }
    }
}
