using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    void LateUpdate()
    {
        transform.position = target.transform.position;
    }

    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;    
    }
}
