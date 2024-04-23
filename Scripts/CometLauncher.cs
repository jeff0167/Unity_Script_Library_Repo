using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometLauncher : MonoBehaviour
{
    public GameObject ElipseObject, spawnPoint1, spawnPoint2, spawnPoint3;
    public GameObject comet;
    List<GameObject> comets = new List<GameObject>();
    public float angle, angleSpeed, distance, i,ii,iii;
    float x, y;
    public event Action OnEvent;

    public void Event()
    {
        OnEvent();
    }

    void Start()
    {
        x = y = 0;
        //InvokeRepeating("SpawnComet", 0, 2);
        SpawnComet();
        SpawnComet();
        SpawnComet();
        StartCoroutine("CometMover");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //comets[0].rb
            for (int i = 0; i < comets.Count; i++) // make look rotation so it will have a forward direction equal to its move direction
            {
                comets[i].transform.LookAt(ElipseObject.transform.position, Vector3.forward);
                comets[i].GetComponent<Rigidbody2D>().velocity = comets[i].transform.right * -10;
            }
            comets.Clear();
        }
    }

    void SpawnComet()
    {
        Vector2 v = Vector2.zero;

        switch (comets.Count)
        {
            case 0:
                v = spawnPoint1.transform.position;
                break;
            case 1:
                v = spawnPoint2.transform.position;
                break;
            case 2:
                v = spawnPoint3.transform.position;
                break;
        }
        GameObject g = Instantiate(comet, v, comet.transform.rotation);
        comets.Add(g);
    }

    IEnumerator CometMover()
    {
        while (true)
        {
            /*  foreach (GameObject item in comets)
              {
                  angle += 0.01f + angleSpeed; // increase speed
                  //xextract += 0.0001f; // exlude by this axis
                  // yextract += 0.0001f;
                   Vector3 currentPos = movingobject.transform.position;

                  item.transform.position = new Vector2(item.transform.position.x - currentPos.x, item.transform.position.y - currentPos.y);

                  x = (item.transform.position.x * Mathf.Cos(angle) - item.transform.position.y * Mathf.Sin(angle))*xextract;
                  y = (item.transform.position.x * Mathf.Sin(angle) + item.transform.position.y * Mathf.Cos(angle))*yextract;

                  x = Mathf.Cos(angle) * distance;
                  y = Mathf.Sin(angle) * distance;

                  Vector3 m = ElipseObject.transform.position;

                  item.transform.position = new Vector3(x, y, 0) + m; //+ new Vector2(currentPos.x, currentPos.y)
              }*/

            angle += 0.01f + angleSpeed; // increase speed
            for (int i = 0; i < comets.Count; i++)
            {
                float plusAngle = 0;
                switch (i)
                {
                    case 0:
                        plusAngle = i;
                        break;
                    case 1:
                        plusAngle = ii;
                        break;
                    case 2:
                        plusAngle = iii;
                        break;
                }

                x = Mathf.Cos(angle + plusAngle) * distance;
                y = Mathf.Sin(angle + plusAngle) * distance;

                Vector3 m = ElipseObject.transform.position;

                comets[i].transform.position = new Vector3(x, y, 0) + m;
            }


            yield return new WaitForEndOfFrame();
        }
    }
}
