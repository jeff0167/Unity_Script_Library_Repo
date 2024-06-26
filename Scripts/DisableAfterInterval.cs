﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterInterval : MonoBehaviour
{
    public float interval;

    void OnEnable()
    {
        Invoke("Disable", interval);
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
