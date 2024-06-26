using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float smoothTime = 0.05f;
    private Vector3 velocity = Vector3.zero;


    void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 1, -10));
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


}
