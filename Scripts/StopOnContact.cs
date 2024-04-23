using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnContact : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.collider.CompareTag("Player"))
        {
            // load lvl
        }
        else
        {
            Destroy(rb);
            transform.parent = other.gameObject.transform;
        }
    }
}
