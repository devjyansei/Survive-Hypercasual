using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemecamera : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        GetComponent<Canvas>().worldCamera = cam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
