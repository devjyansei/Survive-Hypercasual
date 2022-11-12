using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorData : MonoBehaviour
{
    public static MeteorData Instance;

    // METEOR UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int damage; // 40 - 80 - 120 - 160 - 200
    public float spawnInterval; // 1 - 0.9 - 0.8 - 0.7 - 0.6

    // UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int damageCost;
    public int spawnIntervalCost;

    // UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int damageUpgradeAmount;
    public int spawnIntervalUpgradeAmount;

    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int damageUpgradeLevel;
    public int spawnIntervalUpgradeLevel;




    [Header("OTHER SETTINGS")]
    // size sabit kalsýn
    public float size; 
    // meteorauto kullanýyor
    public int spawnRadius;

    // sadece gelistirme için
    public float forcePower;

    private void Awake()
    {
        Instance = this;
    }

    // size ile scale oranla.

}
