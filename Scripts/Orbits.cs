using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour
{
    [SerializeField] float a, b, c, alpha, deltaAlpha;
    [SerializeField] Vector3 center;
    [SerializeField] Transform focu1;

    void Update()
    {
        center = new Vector3(focu1.position.x + c, 0, focu1.position.z);

        transform.position = new Vector3(center.x + a * Mathf.Cos(alpha), 0, center.z + b * Mathf.Sin(alpha));
        c = Mathf.Sqrt((a * a) - (b * b));
        alpha += deltaAlpha * Time.deltaTime;
    }
}
