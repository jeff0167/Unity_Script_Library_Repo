using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GizmosUtil
{

    /// <summary>
    /// Draw a line with local coordinates, with current gizmos parameters
    /// </summary>
    /// <param name="p1">Local 1st coordinates of the line.</param>
    /// <param name="p2">Local 2nt coordinates of the line.</param>
    public static void DrawLocalLine(Transform tr, Vector3 p1, Vector3 p2)
    {
        Gizmos.DrawLine(tr.TransformPoint(p1), tr.TransformPoint(p2));
    }

}

[ExecuteInEditMode]
[RequireComponent(typeof(EdgeCollider2D))]
public class EditUnselectedCollider : MonoBehaviour
{

    public EdgeCollider2D polygonCollider2D { get { return m_EdgeCollider2D; } }
    EdgeCollider2D m_EdgeCollider2D;

    /// <summary>
    /// Should the collider be visible even when the game object is not selected? (experimental: requires no rotation in the hierarchy and local scale only)
    /// </summary>
    [SerializeField] bool alwaysShowCollider;

    void Awake()
    {
        m_EdgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    void OnDrawGizmos()
    {
        if (alwaysShowCollider)
        {
            Vector2[] points = m_EdgeCollider2D.points;
            Gizmos.color = Color.blue;

            // for every point (except for the last one), draw line to the next point
            for (int i = 0; i < points.Length - 1; i++)
            {
                GizmosUtil.DrawLocalLine(transform, (Vector3)points[i], (Vector3)points[i + 1]);
            }
            // for polygons, close with the last segment
            GizmosUtil.DrawLocalLine(transform, (Vector3)points[points.Length - 1], (Vector3)points[0]);
        }
    }

}
