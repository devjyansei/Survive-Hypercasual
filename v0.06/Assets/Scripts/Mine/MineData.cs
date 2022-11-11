using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineData : MonoBehaviour
{
    public static MineData Instance;

    public int damage;
    public int explosionRadius;
    public float fireRate;
    public float detonateDelay;
    public float player_Mine_Distance;


    private void Awake()
    {
        Instance = this;
    }






}
