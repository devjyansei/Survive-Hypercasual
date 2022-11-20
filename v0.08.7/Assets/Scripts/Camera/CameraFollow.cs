using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public Vector3 Offset;
    private void Awake()
    {
        target = FindObjectOfType<PlayerData>().transform;
    }
    void LateUpdate()
    {
        transform.position = target.position + Offset;  
    }
}
