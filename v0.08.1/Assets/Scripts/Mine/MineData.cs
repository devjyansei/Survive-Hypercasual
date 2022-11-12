using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineData : MonoBehaviour
{
    public static MineData Instance;

    // MINE UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int damage; // 50-75-100-125-150
    public float explosionRadius; // 1den baslayýp 2 ye gidecek.  1.25  1.50 1.75  2

    // UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int damageCost;
    public int explosionRadiusCost;

    // UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int damageUpgradeAmount;
    public int explosionRadiusUpgradeAmount;


    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int damageUpgradeLevel;
    public int explosionRadiusUpgradeLevel;



    // GELISTIRME ICIN
    [Header("OTHER SETTINGS")]
    public float detonateDelay;
    public float player_Mine_Distance;


    private void Awake()
    {
        Instance = this;
    }






}
