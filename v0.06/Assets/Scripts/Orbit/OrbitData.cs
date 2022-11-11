using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitData : MonoBehaviour
{
    public static OrbitData Instance;

    public int rotateSpeed;
    public int damage;
    private void Awake()
    {
        Instance = this;
    }
}
