using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
    public static FieldData Instance;

    Vector3 radius;

    //FIELD UPGRADES
    [Header("ATTRIBUTE STATS")]
    public float damage; 
    public float hitInterval; 
    public float radiusMultiplier; 

    // UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int damageCost;
    public int hitIntervalCost;
    public int radiusCost;

    // UPGRADE COST RAISES
    [Header("UPGRADE COST RAISES")]
    public int damageCostRaise;
    public int hitIntervalCostRaise;
    public int radiusCostRaise;

    //UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int damageUpgradeAmount;
    public float hitIntervalUpgradeAmount;
    public float radiusUpgradeAmount;



    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int damageUpgradeLevel;
    public int hitIntervalUpgradeLevel;
    public int radiusUpgradeLevel;



    private void Awake()
    {
        Instance = this;       
    }
    private void Start()
    {       
        radius = transform.localScale;
    }
    private void Update()
    {
        transform.localScale = radius*radiusMultiplier;
    }    


}
