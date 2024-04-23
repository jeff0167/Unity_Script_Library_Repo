using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    float h, v, hh, vv;
    public float moveSpeed, rotationSpeed;

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(h, 0, v).normalized * moveSpeed, Space.Self);
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel")) * moveSpeed, Space.Self);

        // transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * rotationSpeed); // what is wrong with this?? to angles can be set at once and lead to overlap in  values
        //transform.Rotate(Vector3.right, Input.GetAxisRaw("Mouse Y") * -rotationSpeed); // so the z rotation gets changed??
        hh += Input.GetAxisRaw("Mouse X") * rotationSpeed;
        vv += Input.GetAxisRaw("Mouse Y") * -rotationSpeed;

        transform.localRotation = Quaternion.Euler(vv, hh, 0);
    }
}
