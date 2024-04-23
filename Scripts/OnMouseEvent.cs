using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseEvent : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse enter: " + gameObject);
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse exit: " + gameObject);
    }

}
