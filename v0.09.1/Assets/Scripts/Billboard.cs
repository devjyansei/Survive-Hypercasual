using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cam;
    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
