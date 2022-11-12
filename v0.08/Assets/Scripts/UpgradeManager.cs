using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public OrbitData orbitData;
    public FieldData fieldData;
    public BulletData bulletData;
    public MeteorData meteorData;
    public MineData mineData;


    public Image[] orbitAmountImages;
    public Image[] orbitDamageImages;
    public Image[] orbitSpeedImages;

    public Image[] fieldDamageImages;
    public Image[] fieldHitIntervalImages;
    public Image[] fieldRadiusImages;

    public Image[] bulletDamageImages;
    public Image[] bulletSpeedImages;
    public Image[] bulletFireRateImages;

    public Image[] meteorDamageImages;
    public Image[] meteorspawnIntervalImages;

    public Image[] mineDamageImages;
    public Image[] mineexplosionRadiusImages;

    //------------------------- kodu 5 fonksiyon ile optimize et ------------------


    //  ORBIT UPGRADES
    public void UpgradeOrbitAmount()
    {
        if (Bank.Instance.goldAmount >= orbitData.orbitAmountCost)
        {
            orbitData.orbitAmount += orbitData.amountUpgradeAmount;

            orbitData.amountUpgradeLevel++;


            for (int i = 0; i < orbitData.amountUpgradeLevel; i++)
            {
                orbitAmountImages[i].color = Color.red;
            }
           
        }
    }
    public void UpgradeOrbitDamage()
    {
        if (Bank.Instance.goldAmount >= orbitData.damageCost)
        {
            orbitData.damage += orbitData.damageUpgradeAmount;

            orbitData.damageUpgradeLevel++;

            for (int i = 0; i < orbitData.damageUpgradeLevel; i++)
            {
                orbitDamageImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeOrbitSpeed()
    {
        if (Bank.Instance.goldAmount >= orbitData.rotationSpeedCost)
        {
            orbitData.rotateSpeed += orbitData.speedUpgradeAmount;

            orbitData.speedUpgradeLevel++;

            for (int i = 0; i < orbitData.speedUpgradeLevel; i++)
            {
                orbitSpeedImages[i].color = Color.red;
            }
        }
    }

    // FIELD UPGRADES

    public void UpgradeFieldDamage()
    {
        if (Bank.Instance.goldAmount >= fieldData.damageCost)
        {
            fieldData.damage += fieldData.damageUpgradeAmount;

            fieldData.damageUpgradeLevel++;

            for (int i = 0; i < fieldData.damageUpgradeLevel; i++)
            {
                fieldDamageImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeFieldHitInterval()
    {
        if (Bank.Instance.goldAmount >= fieldData.hitIntervalCost)
        {
            fieldData.hitInterval += fieldData.hitIntervalUpgradeAmount;

            fieldData.hitIntervalUpgradeLevel++;

            for (int i = 0; i < fieldData.hitIntervalUpgradeLevel; i++)
            {
                fieldHitIntervalImages[i].color = Color.red;
            }

        }
    }
    public void UpgradeFieldRadius()
    {
        if (Bank.Instance.goldAmount >= fieldData.radiusCost)
        {
            fieldData.radiusMultiplier += fieldData.radiusUpgradeAmount;

            fieldData.radiusUpgradeLevel++;

            for (int i = 0; i < fieldData.radiusUpgradeLevel; i++)
            {
                fieldRadiusImages[i].color = Color.red;
            }
        }
    }


    // BULLET UPGRADES

    public void UpgradeBulletDamage()
    {
        if (Bank.Instance.goldAmount >= bulletData.damageCost)
        {
            bulletData.damage += bulletData.damageUpgradeAmount;

            bulletData.damageUpgradeLevel++;

            for (int i = 0; i < bulletData.damageUpgradeLevel; i++)
            {
                bulletDamageImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeBulletSpeed()
    {
        if (Bank.Instance.goldAmount >= bulletData.speedCost)
        {
            bulletData.speed += bulletData.speedUpgradeAmount;

            bulletData.speedUpgradeLevel++;

            for (int i = 0; i < bulletData.speedUpgradeLevel; i++)
            {
                bulletSpeedImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeBulletFireRate()
    {
        if (Bank.Instance.goldAmount >= bulletData.fireRateCost)
        {
            bulletData.fireRate += bulletData.fireRateUpgradeAmount;

            bulletData.fireRateUpgradeLevel++;

            for (int i = 0; i < bulletData.fireRateUpgradeLevel; i++)
            {
                bulletFireRateImages[i].color = Color.red;
            }
        }
    }



    // METEOR UPGRADES 

    public void UpgradeMeteorDamage() 
    { 
        if (Bank.Instance.goldAmount >= meteorData.damageCost)
        {
            meteorData.damage += meteorData.damageUpgradeAmount;

            meteorData.damageUpgradeLevel++;

            for (int i = 0; i < meteorData.damageUpgradeLevel; i++)
            {
                meteorDamageImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeMeteorSpawnInterval()
    {
        if (Bank.Instance.goldAmount >= meteorData.spawnIntervalCost)
        {
            meteorData.spawnInterval += meteorData.spawnIntervalUpgradeAmount;

            meteorData.spawnIntervalUpgradeLevel++;

            for (int i = 0; i < meteorData.spawnIntervalUpgradeLevel; i++)
            {
                meteorspawnIntervalImages[i].color = Color.red;
            }
        }
    }


    // MINE UPGRADES

    public void UpgradeMineDamage()
    {
        if (Bank.Instance.goldAmount >= mineData.damageCost)
        {
            mineData.damage += mineData.damageUpgradeAmount;

            mineData.damageUpgradeLevel++;

            for (int i = 0; i < mineData.damageUpgradeLevel; i++)
            {
                mineDamageImages[i].color = Color.red;
            }
        }
    }
    public void UpgradeMineExplosionRadius()
    {
        if (Bank.Instance.goldAmount >= mineData.explosionRadiusCost)
        {
            mineData.explosionRadius += mineData.explosionRadiusUpgradeAmount;

            mineData.explosionRadiusUpgradeLevel++;

            for (int i = 0; i < mineData.explosionRadiusUpgradeLevel; i++)
            {
                mineexplosionRadiusImages[i].color = Color.red;
            }
        }
    }

}
