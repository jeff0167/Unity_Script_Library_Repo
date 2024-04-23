using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseComets : MonoBehaviour
{
    [SerializeField]
    GameObject comet;
    List<GameObject> comets = new List<GameObject>();
    [SerializeField]
    GameObject spawnPoint1, spawnPoint2, spawnPoint3;

    void Start()
    {
        Spawn();
        Spawn();
        Spawn();
    }

    void Spawn()
    {
        Vector2 v = Vector2.zero;

        switch (comets.Count)
        {
            case 0:
                v = spawnPoint1.transform.position;
                break;
            case 1:
                v = spawnPoint2.transform.position;
                break;
            case 2:
                v = spawnPoint3.transform.position;
                break;
        }
        GameObject g = Instantiate(comet, v, comet.transform.rotation);
        g.transform.parent = transform;
        comets.Add(g);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < comets.Count; i++)
            {
                comets[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
            }
            comets.Clear();
        }
    }
}
