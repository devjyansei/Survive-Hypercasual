using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorData : MonoBehaviour
{
    public static MeteorData Instance;

    public int damage;
    public float spawnInterval;
    public float size;
    public int spawnRadius;
    public int spawnAmount; // belki
    public float forcePower;

    private void Awake()
    {
        Instance = this;
    }

    // size ile scale oranla.



}
