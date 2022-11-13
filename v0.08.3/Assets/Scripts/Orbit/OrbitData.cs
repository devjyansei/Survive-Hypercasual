using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitData : MonoBehaviour
{
    public static OrbitData Instance;

    // ORBIT UPGRADES
    [Header("ATTRIBUTE STATS")]
    public int orbitAmount; // 1 - 2 - 3 - 4
    public int damage;   // 10-20-30-40-50
    public int rotateSpeed; // 90 - 180 - 270 - 360

    // UPGRADE COSTS
    [Header("UPGRADE COSTS")]
    public int amountCost;
    public int damageCost;
    public int rotationSpeedCost;


    // UPGRADE COST RAISES
    [Header("UPGRADE COST RAISES")]
    public int amountCostRaise;
    public int damageCostRaise;
    public int rotationSpeedCostRaise;


    // UPGRADE AMOUNTS
    [Header("UPGRADE AMOUNTS")]
    public int amountUpgradeAmount;
    public int damageUpgradeAmount;
    public int speedUpgradeAmount;


    // CURRENT UPGRADE LEVELS
    [Header("CURRENT UPGRADE LEVELS")]
    public int amountUpgradeLevel;
    public int damageUpgradeLevel;
    public int speedUpgradeLevel;





    // REFERENCES
    [Header("REFERENCES")]
    public GameObject orbit1;
    public GameObject orbit2;
    public GameObject orbit3;
    public GameObject orbit4;

    private void Awake()
    {
        Instance = this;
        SetOrbitAmount();
    }
    private void Start()
    {
        
    }
    void SetOrbitAmount() // transformlarýný her set edildiðinde duzeltmem gerekebilir.
    {
        if (orbitAmount == 1)
        {
            orbit1.SetActive(true);
        }
        else if (orbitAmount == 2)
        {
            orbit1.SetActive(true);
            orbit2.SetActive(true);
        }
        else if (orbitAmount == 3)
        {
            orbit1.SetActive(true);
            orbit2.SetActive(true);
            orbit3.SetActive(true);
        }
        else if (orbitAmount == 4)
        {
            orbit1.SetActive(true);
            orbit2.SetActive(true);
            orbit3.SetActive(true);
            orbit4.SetActive(true);
        }

    }



}
