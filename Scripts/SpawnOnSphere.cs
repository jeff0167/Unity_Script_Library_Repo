using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSphere : MonoBehaviour
{
    public GameObject SpawnLocation, spawnObject;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Spawn();
    }

    void Spawn()
    {
        GameObject g = Instantiate(spawnObject, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        g.GetComponent<Rigidbody>().velocity = g.transform.forward * 2;
    }
}
