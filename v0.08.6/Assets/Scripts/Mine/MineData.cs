using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineData : MonoBehaviour
{
    public static MineData Instance;

    // MINE UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int damage; // 50-75-100-125-150
    public float explosionRadius; // dengeleme lazým

    // UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int damageCost;
    public int explosionRadiusCost;

    // UPGRADE COST RAISES
    [Header("UPGRADE COST RAISES")]
    public int damageCostRaise;
    public int explosionRadiusCostRaise;



    // UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int damageUpgradeAmount;
    public float explosionRadiusUpgradeAmount;


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
