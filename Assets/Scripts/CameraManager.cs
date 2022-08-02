using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float SmoothSpeed = 0.125f;

    void FixedUpdate()
    {
        if (Target != null) // obje varsa
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = smoothedPosition;
    }
}
