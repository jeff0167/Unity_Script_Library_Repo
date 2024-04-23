using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    GameObject cam;

    [SerializeField]
    AudioClip audioClip;

    int index = 0;

    private void Awake()
    {
        cam = Camera.main.GetComponent<GameObject>();
    }

    void OnEnable()
    {
        if (index != 0) // dont play on first start op, if instantiated from pool then it will have a moment where it is active and therefore enabled
        {
            cam.GetComponent<AudioSource>().PlayOneShot(audioClip);
        }
        else index++;
    }
}
