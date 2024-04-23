using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField]
    Color startColor, endColor;

    [SerializeField]
    float intensityEmission;  // you cannot simply get the emission color from the material, must just have to match it manually
 
    void Start()
    {
        StartCoroutine("LerpColor");
    }

    IEnumerator LerpColor()
    {
        while (true)
        {
            float changeRate = Mathf.PingPong(Time.time / 2, 1);
            float r = Mathf.Lerp(startColor.r, endColor.r, changeRate);
            float g = Mathf.Lerp(startColor.g, endColor.g, changeRate);
            float b = Mathf.Lerp(startColor.b, endColor.b, changeRate);

           // GetComponent<MeshRenderer>().material.color = new Color(r, g, b); // no emmission

            GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(r,g,b) * intensityEmission * 9); // this intensity doesn't match actual mat intensity thereforce the *9

            yield return new WaitForSeconds(0.032f);
        }
    }
}
