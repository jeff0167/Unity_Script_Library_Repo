using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTipperController : MonoBehaviour
{
    float h, v;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject plane;

    void Update()
    {
        h = Input.GetAxis("Mouse X") * speed;
        v = Input.GetAxis("Mouse Y") * speed;

        plane.transform.Rotate(Vector3.right, v*-1);
        plane.transform.Rotate(Vector3.forward, h);

        Vector3 vv = transform.rotation.eulerAngles; // ignore y rotation!! It´s amazing!!
        vv = new Vector3(vv.x, 180, vv.z);
        plane.transform.rotation = Quaternion.Euler(vv);
    }
}
