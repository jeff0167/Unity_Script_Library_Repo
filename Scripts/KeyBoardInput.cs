using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    readonly List<KeyCode> input = new List<KeyCode>() { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0,
        KeyCode.Q,KeyCode.W, KeyCode.E,KeyCode.R,KeyCode.T,KeyCode.Y,KeyCode.U,KeyCode.I,KeyCode.O,KeyCode.P,KeyCode.A,KeyCode.S,KeyCode.D,
        KeyCode.F,KeyCode.G,KeyCode.H, KeyCode.J, KeyCode.K,KeyCode.L,KeyCode.Z,KeyCode.X,KeyCode.C,KeyCode.V,KeyCode.B,KeyCode.N,KeyCode.M,
    };

    void Update()
    {
        //foreach (KeyCode item in input)
        //{
        //    if (Input.GetKeyDown(item))
        //    {
        //        Debug.Log(item);
        //    }
        //}

        Debug.Log(Input.inputString); // this works though space and backspace are empty string

        //if(Input.anyKeyDown);   // can get any key, but can't tell which one is pressed
    }
}
