using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panorama : MonoBehaviour
{
    [SerializeField]
    GameObject player, background, layer1, layer2;

    void LateUpdate() // set the objects transform to be influence by players position
    {
        transform.position = new Vector3(player.transform.position.x * 0.99f, player.transform.position.y * 0.99f, 100);
    }
}
