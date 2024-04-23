using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveObjectToMousePos3D : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Rigidbody rb;

    [SerializeField]
    float MoveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector3 targetPos = new Vector3(raycastHit.point.x, 0, raycastHit.point.z); // setting y pos at 0
                MoveTowardPos(targetPos);

                //target.position = targetPos;
            }
        }
    }

    void MoveTowardPos(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine("LerpToPos", pos);
    }

    IEnumerator LerpToPos(Vector3 pos)
    {
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * MoveSpeed;
            target.position = Vector3.Lerp(target.position, pos, t);
            yield return new WaitForEndOfFrame();
        }
    }
}
