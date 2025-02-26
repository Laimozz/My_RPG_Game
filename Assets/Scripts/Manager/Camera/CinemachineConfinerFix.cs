using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineConfinerFix : MonoBehaviour
{
    private CinemachineConfiner2D confiner;
    private PolygonCollider2D boundingShape; // Gán trong Inspector hoặc tìm tự động
    void Start()
    {
        confiner = GetComponent<CinemachineConfiner2D>();

        if (confiner != null)
        {
            boundingShape = FindObjectOfType<PolygonCollider2D>(); // Tìm Polygon Collider trong Scene

            if (boundingShape != null)
            {
                confiner.m_BoundingShape2D = boundingShape;
                confiner.InvalidateCache();
            }
            else
            {
                Debug.LogWarning("Không tìm thấy PolygonCollider2D trong Scene!");
            }
        }
    }
}
