using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnContact : MonoBehaviour
{
    [SerializeField]
    Vector2 offset;
    [SerializeField]
    string tag;
    [SerializeField]
    GameObject SpawnObject;

    void OnCollisionEnter(Collision other) // if hit, do effect, can be used for object pooling objects that gets disabled, might need rb
    {
        if (other.gameObject.CompareTag(tag))
        {
            GameObject g = Instantiate(SpawnObject, transform.position, Quaternion.identity);
            g.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform); // check the tag and if it shows up in build
            UIPopOpEffect UI = g.GetComponent<UIPopOpEffect>();
            UI.PopUp(transform, offset);
        }
    }
}
