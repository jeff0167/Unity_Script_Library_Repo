using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEffect : MonoBehaviour
{
    [SerializeField]
    string tag;
    [SerializeField]
    int effectValue;
    [SerializeField]
    GameObject effect;

    void OnTriggernEnter2D(Collision2D other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.gameObject.CompareTag(tag))
        {
            this.enabled = false; // spawn effect from objectpool?           
        }
    }
}
