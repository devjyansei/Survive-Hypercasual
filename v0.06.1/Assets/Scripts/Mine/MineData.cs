using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineData : MonoBehaviour
{
    public static MineData Instance;

    // MINE UPGRADES
    public int damage; // 50-75-100-125-150
    public float explosionRadius; // 1den baslayýp 2 ye gidecek.  1.25  1.50 1.75  2

    // GELISTIRME ICIN
    public float detonateDelay;
    public float player_Mine_Distance;


    private void Awake()
    {
        Instance = this;
    }






}
