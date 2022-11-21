using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public static BulletData Instance;

    // BULLET UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int speed; 
    public float damage;
    public float fireRate; 

    //UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int speedCost;
    public int damageCost;
    public int fireRateCost;

    // UPGRADE COST RAISES
    [Header("UPGRADE COST RAISES")]
    public int speedCostRaise;
    public int damageCostRaise;
    public int fireRateCostRaise;


    //UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int speedUpgradeAmount;
    public int damageUpgradeAmount;
    public float fireRateUpgradeAmount;



    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int speedUpgradeLevel;
    public int damageUpgradeLevel;
    public int fireRateUpgradeLevel;



    private void Awake()
    {
        Instance = this;
    }

}

