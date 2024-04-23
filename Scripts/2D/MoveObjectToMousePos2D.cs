using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToMousePos2D : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }
}
