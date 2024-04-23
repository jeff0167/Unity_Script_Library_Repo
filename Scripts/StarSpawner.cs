using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Star, player;
    Rigidbody rb;
    [SerializeField]
    int starAmount;
    [SerializeField]
    float MoveSpeed;
    float h, v;
    SlowTime TimeStoper;

    [SerializeField]
    float timeScale = 0.5f;

    void Start()
    {
        TimeStoper = this.GetComponent<SlowTime>();
        rb = player.GetComponent<Rigidbody>();
        rb.velocity = Vector3.right * MoveSpeed;
        for (int i = 0; i < starAmount; i++)
        {
            GameObject g = Instantiate(Star, new Vector3(Random.Range(-60f, 89f), Random.Range(50f, 1500f), 1), Quaternion.identity);
            float index = Random.Range(0.3f, 1.5f);
            g.transform.localScale = new Vector3(index,index,index);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TimeStoper.SlowingTime(timeScale);
        }
    }

    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        v = Input.GetAxisRaw("Vertical") * MoveSpeed;
        if (h != 0)
        {
            rb.velocity = Vector3.right * h;
        }
        else if(v != 0)
        {
            rb.velocity = Vector3.up * v;
        }
    }
}
