using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    private void Awake()
    {
        target = FindObjectOfType<OrbitPivot>().gameObject;
    }
    void Update()
    {
        transform.RotateAround(target.transform.position,Vector3.up,OrbitData.Instance.rotateSpeed*Time.deltaTime);
    }
}
