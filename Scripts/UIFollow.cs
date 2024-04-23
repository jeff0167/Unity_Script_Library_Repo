using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour // keep all parent UI at 1 and try keep childs at 1 as well, use anchor and pivot so it´s placement stays the same
{
    Camera cam; // in all display sizes

    [SerializeField]
    GameObject target;

    [SerializeField]
    Vector2 offset;

    void Awake()
    {
        cam = Camera.main;
    }

    public void GiveTarget(GameObject t, Vector2 v)
    {
        target = t;
        offset = v;
    }

    void FixedUpdate()
    {
        if (!target) return;
        Vector2 screenPos = cam.WorldToScreenPoint(target.transform.position);
        transform.position = screenPos + offset;
    }
}
