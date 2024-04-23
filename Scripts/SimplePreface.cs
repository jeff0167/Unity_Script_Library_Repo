using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePreface : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("Supp yall", "I´ts ya boy Asmongold"); // the name and then the value
    }

    public void Safe(string name, int index)
    {
        PlayerPrefs.SetInt(name, index);
    }
    public void Safe(string name, float index)
    {
        PlayerPrefs.SetFloat(name, index);
    }
    public void Safe(string name, string index)
    {
        PlayerPrefs.SetString(name, index);
    }


    public int GetInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
    public float GetFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }
    public string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }
}
