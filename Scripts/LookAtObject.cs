using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToLookAt;

    void Update()
    {
        transform.LookAt(transform, objectToLookAt.transform.position);
    }
}
