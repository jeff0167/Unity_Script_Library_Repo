using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTimeScale : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeScale;
    void Update()
    {
        timeScale.text = Time.timeScale.ToString();
    }
}
