using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerrator : MonoBehaviour
{
    [SerializeField]
    GameObject gridObject;

    [SerializeField]
    Vector2 gridSize, gridSpacing;

    [SerializeField]
    float altitude;

    List<GameObject> gridObjects;

    Vector2 tempGrid;

    void Start()
    {
        CreateGrid();
    }

    private void Update()
    {
        if(tempGrid != gridSize)
        {
            DeleteGrid();  // only for quick editing, list's not nescessary for performance use
            CreateGrid();
        }
        tempGrid = gridSize;
    }

    void DeleteGrid()
    {
        foreach (var item in gridObjects)
        {
            Destroy(item);
        }
    }

    void CreateGrid()
    {
        gridObjects = new List<GameObject>();
        Vector3 offset = Vector3.zero;
        for (float i = 0; i < gridSize.x * gridObject.transform.localScale.x; i += gridObject.transform.localScale.x)
        {
            for (float j = 0; j < gridSize.y * gridObject.transform.localScale.y; j += gridObject.transform.localScale.z)
            {
                GameObject g = Instantiate(gridObject, new Vector3(i, altitude, j) + offset, Quaternion.identity);
                gridObjects.Add(g);
                offset += new Vector3(0, 0, gridSpacing.y);
            }
           // offset += new Vector3(gridSpacing.x, 0, offset.z - offset.z * 2);
            offset = new Vector3(gridSpacing.x + offset.x, 0, offset.y + gridSpacing.y);
        }
    }
}
