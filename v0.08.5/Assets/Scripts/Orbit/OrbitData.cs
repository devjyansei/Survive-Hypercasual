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
    public int rotateSpeed; // 90 - 180 - 270 - 360 - 450

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


    //orbits list
    public GameObject[] orbits;
    public Vector3[] orbitsStartPositions;
    private void Awake()
    {
        Instance = this;
    }
    
    public void SetOrbitAmount() // transformlarýný her set edildiðinde duzeltmem gerekebilir.
    {
        if (orbitAmount == 1)
        {
            
            for (int i = 0; i < orbits.Length; i++)
            {
                orbits[i].SetActive(false);
                
            }
            for (int i = 0; i < orbitAmount; i++)
            {
                orbits[i].SetActive(true);              
            }


            amountUpgradeLevel = orbitAmount-1;

        }
        else if (orbitAmount == 2)
        {

            for (int i = 0; i < orbits.Length; i++)
            {
                orbits[i].SetActive(false);

            }
            for (int i = 0; i < orbitAmount; i++)
            {
                orbits[i].SetActive(true);
            }



            amountUpgradeLevel = orbitAmount - 1;

        }
        else if (orbitAmount == 3)
        {

            for (int i = 0; i < orbits.Length; i++)
            {
                orbits[i].SetActive(false);

            }
            for (int i = 0; i < orbitAmount; i++)
            {
                orbits[i].SetActive(true);
            }




            amountUpgradeLevel = orbitAmount - 1;

        }
        else if (orbitAmount == 4)
        {
            for (int i = 0; i < orbits.Length; i++)
            {
                orbits[i].SetActive(false);

            }
            for (int i = 0; i < orbitAmount; i++)
            {
                orbits[i].SetActive(true);
            }

            amountUpgradeLevel = orbitAmount - 1;

        }

    }
    public void ResetOrbitPositions()
    {
        for (int i = 0; i < orbitsStartPositions.Length; i++)
        {
            orbits[i].transform.localPosition = orbitsStartPositions[i];
        }
        
    }
    
  
}
