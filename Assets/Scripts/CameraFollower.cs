using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    //what to follow
    public Transform target;

    //to be away from player
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
