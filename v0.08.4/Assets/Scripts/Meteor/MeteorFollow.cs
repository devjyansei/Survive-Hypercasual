using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFollow : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = target.position + new Vector3(0,10,0);
    }
    
}
