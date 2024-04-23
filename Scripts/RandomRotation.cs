using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    void Start()
    {
        Invoke("Rotation",0);
    }
   
    void Rotation()
    {
        Invoke("Rotation", Random.Range(0.7f,6f));
        Vector3 v;

        int index = Random.Range(0, 3); // it goes from [0 - ]3    so 0-1-2, the last nr is the one that is left out!!
        if(index == 1)
        {
            v = transform.right;
        }
        else if(index == 2)
        {
            v = transform.up;
        }
        else v = transform.forward;

        float vv = Random.Range(-0.31f, 0.31f);

        StopAllCoroutines();
        StartCoroutine(Rotation(v, vv));
    }

    IEnumerator Rotation(Vector3 v, float rotation)
    {
        while (true)
        {
            transform.Rotate(v, rotation);
            yield return null;
        }
    }
}
