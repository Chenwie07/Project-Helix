using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothness = 0.03f;

    private void Start()
    {
        // distance of our current camera position away from the target, such that the camera won't take the same 
        // position as the target itself when it's following. 
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
        //transform.position = target.position + offset;
    }
}
