using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public static BulletData Instance;

    // BULLET UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int speed; // 2 DEN BAÞLAYIP  4  6 ya KADAR GÝDECEK.
    public int damage; // 10 15 20 25 30 35
    public float fireRate; // 1.1 - 0.9 - 0.7 - 0.5 - 0.3 - 0.1

    //UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int damageCost;
    public int speedCost;
    public int fireRateCost;

    //UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int damageUpgradeAmount;
    public int speedUpgradeAmount;
    public int fireRateUpgradeAmount;


    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int damageUpgradeLevel;
    public int speedUpgradeLevel;
    public int fireRateUpgradeLevel;






    private void Awake()
    {
        Instance = this;
    }

}

