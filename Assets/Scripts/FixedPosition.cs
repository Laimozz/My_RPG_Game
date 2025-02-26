using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; // Lưu vị trí ban đầu
    }

    void LateUpdate()
    {
        transform.position = originalPosition; // Luôn đặt lại vị trí cũ
    }
}
