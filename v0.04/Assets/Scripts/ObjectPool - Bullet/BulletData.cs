using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public static BulletData Instance;

    public int speed;
    public int damage;
    public float fireRate;
    public int penetrateAmount;
    public int spawnAmount; // Zor olabilir.

    private void Awake()
    {
        Instance = this;
    }

}

