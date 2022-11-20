using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [Header("OBJECT DATA'S")]
    public OrbitData orbitData;
    public FieldData fieldData;
    public BulletData bulletData;
    //public MeteorData meteorData;
    public MineData mineData;

    [Header("ORBIT IMAGES")]
    public Image[] orbitAmountImages;
    public Image[] orbitDamageImages;
    public Image[] orbitSpeedImages;

    [Header("FIELD IMAGES")]
    public Image[] fieldDamageImages;
    public Image[] fieldHitIntervalImages;
    public Image[] fieldRadiusImages;

    [Header("BULLET IMAGES")]
    public Image[] bulletDamageImages;
    public Image[] bulletSpeedImages;
    public Image[] bulletFireRateImages;

   /* [Header("METEOR IMAGES")]
    public Image[] meteorDamageImages;
    public Image[] meteorspawnIntervalImages;*/

    [Header("MINE IMAGES")]
    public Image[] mineDamageImages;
    public Image[] mineexplosionRadiusImages;



    [Header("ORBIT VALUE TEXT REFERENCES")]
    public TextMeshProUGUI orbitAmountText;
    public TextMeshProUGUI orbitDamageText;
    public TextMeshProUGUI orbitSpeedText;

    [Header("FIELD VALUE TEXT REFERENCES")]
    public TextMeshProUGUI fieldDamageText;
    public TextMeshProUGUI fieldHitIntervalText;
    public TextMeshProUGUI fieldRadiusText;

    [Header("BULLET VALUE TEXT REFERENCES")]
    public TextMeshProUGUI bulletDamageText;
    public TextMeshProUGUI bulletSpeedText;
    public TextMeshProUGUI bulletFireRateText;

  /*  [Header("METEOR VALUE TEXT REFERENCES")]
    public TextMeshProUGUI meteorDamageText;
    public TextMeshProUGUI meteorSpawnIntervalText;*/

    [Header("MINE VALUE TEXT REFERENCES")]
    public TextMeshProUGUI mineDamageText;
    public TextMeshProUGUI mineExplosionRadiusText;








    //--------------------- kodu 5 fonksiyon ile optimize etmeye calis ------------------//

    //--------------------- fonksiyonlara bölüp okunabilirligi arttir ------------------//

    private void Awake()
    {
        // INSTANCE 
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



        // -----------------VALUE SETS-----------------

        // ORBIT
        orbitAmountText.text = orbitData.amountCost.ToString();
        orbitDamageText.text = orbitData.damageCost.ToString();
        orbitSpeedText.text = orbitData.rotationSpeedCost.ToString();

        // FIELD
        fieldDamageText.text = fieldData.damageCost.ToString();
        fieldHitIntervalText.text = fieldData.hitIntervalCost.ToString();
        fieldRadiusText.text = fieldData.radiusCost.ToString();

        // BULLET
        bulletSpeedText.text = bulletData.speedCost.ToString();
        bulletDamageText.text = bulletData.damageCost.ToString();
        bulletFireRateText.text = bulletData.fireRateCost.ToString();

        /*// METEOR
        meteorDamageText.text = meteorData.damageCost.ToString();
        meteorSpawnIntervalText.text = meteorData.spawnIntervalCost.ToString();
        */

        // MINE 
        mineDamageText.text = mineData.damageCost.ToString();
        mineExplosionRadiusText.text = mineData.explosionRadiusCost.ToString();

    }




    //  ORBIT UPGRADES
    public void UpgradeOrbitAmount()
    {

        if (orbitData.amountUpgradeLevel < orbitAmountImages.Length)
        {

        

            if (Bank.Instance.goldAmount >= orbitData.amountCost  &&  !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.orbit))
            {
                //gold update
                Bank.Instance.DecreaseGold(orbitData.amountCost);

                // upgrade
                orbitData.orbitAmount += orbitData.amountUpgradeAmount;

                orbitData.amountUpgradeLevel++;

                orbitData.SetOrbitAmount();
                orbitData.ResetOrbitPositions();

                // value text guncellemesi
                orbitData.amountCost += orbitData.amountCostRaise;
                orbitAmountText.text = orbitData.amountCost.ToString();

                // ui guncellemesi

                for (int i = 0; i < orbitData.amountUpgradeLevel; i++)
                {
                    orbitAmountImages[i].color = Color.green;
                }


            }

            else
            {
                
                Debug.Log("Bu özelliðe sahip deðilsin");
                
                // PARA YETERSIZ YAZDIR.
            }


        }

       
    }
    public void UpgradeOrbitDamage()
    {
        if (orbitData.damageUpgradeLevel < orbitDamageImages.Length  &&  !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.orbit))
        {
            if (Bank.Instance.goldAmount >= orbitData.damageCost)
            {
                Bank.Instance.DecreaseGold(orbitData.damageCost);

                orbitData.damage += orbitData.damageUpgradeAmount;

                orbitData.damageUpgradeLevel++;

                orbitData.damageCost += orbitData.damageCostRaise;
                orbitDamageText.text = orbitData.damageCost.ToString();

                for (int i = 0; i < orbitData.damageUpgradeLevel; i++)
                {
                    orbitDamageImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);
                PlayerPrefs.SetInt("OrbitDamage", orbitData.damage);
                PlayerPrefs.SetInt("OrbitDamageUpgradeLevel", orbitData.damageUpgradeLevel);

            }
        }
        
    }
    public void UpgradeOrbitSpeed()
    {
        if (orbitData.speedUpgradeLevel < orbitSpeedImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.orbit))
        {
            if (Bank.Instance.goldAmount >= orbitData.rotationSpeedCost)
            {

                Bank.Instance.DecreaseGold(orbitData.rotationSpeedCost);

                orbitData.rotateSpeed += orbitData.speedUpgradeAmount;

                orbitData.speedUpgradeLevel++;

                orbitData.rotationSpeedCost += orbitData.rotationSpeedCostRaise;
                orbitSpeedText.text = orbitData.rotationSpeedCost.ToString();

                for (int i = 0; i < orbitData.speedUpgradeLevel; i++)
                {
                    orbitSpeedImages[i].color = Color.green;
                }
            }
        }

        
    }

    // FIELD UPGRADES

    public void UpgradeFieldDamage()
    {
        if (fieldData.damageUpgradeLevel < fieldDamageImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.field))
        {

            if (Bank.Instance.goldAmount >= fieldData.damageCost)
            {
                Bank.Instance.DecreaseGold(fieldData.damageCost);

                fieldData.damage += fieldData.damageUpgradeAmount;

                fieldData.damageUpgradeLevel++;

                fieldData.damageCost += fieldData.damageCostRaise;
                fieldDamageText.text = fieldData.damageCost.ToString();

                for (int i = 0; i < fieldData.damageUpgradeLevel; i++)
                {
                    fieldDamageImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }

        }
       
    }
    public void UpgradeFieldHitInterval()
    {
        if (fieldData.hitIntervalUpgradeLevel < fieldHitIntervalImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.field))
        {
            if (Bank.Instance.goldAmount >= fieldData.hitIntervalCost)
            {
                Bank.Instance.DecreaseGold(fieldData.hitIntervalCost);


                fieldData.hitInterval -= fieldData.hitIntervalUpgradeAmount;

                fieldData.hitIntervalUpgradeLevel++;

                fieldData.hitIntervalCost += fieldData.hitIntervalCostRaise;
                fieldHitIntervalText.text = fieldData.hitIntervalCost.ToString();

                for (int i = 0; i < fieldData.hitIntervalUpgradeLevel; i++)
                {
                    fieldHitIntervalImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }
    public void UpgradeFieldRadius()
    {
        if (fieldData.radiusUpgradeLevel < fieldRadiusImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.field))
        {
            if (Bank.Instance.goldAmount >= fieldData.radiusCost)
            {

                Bank.Instance.DecreaseGold(fieldData.radiusCost);


                fieldData.radiusMultiplier += fieldData.radiusUpgradeAmount;

                fieldData.radiusUpgradeLevel++;

                fieldData.radiusCost += fieldData.radiusCostRaise;
                fieldRadiusText.text = fieldData.radiusCost.ToString();

                for (int i = 0; i < fieldData.radiusUpgradeLevel; i++)
                {
                    fieldRadiusImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
     
    }


    // BULLET UPGRADES

    public void UpgradeBulletDamage()
    {
        if (bulletData.damageUpgradeLevel < bulletDamageImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.bullet))
        {
            if (Bank.Instance.goldAmount >= bulletData.damageCost)
            {
                Bank.Instance.DecreaseGold(bulletData.damageCost);


                bulletData.damage += bulletData.damageUpgradeAmount;

                bulletData.damageUpgradeLevel++;

                bulletData.damageCost += bulletData.damageCostRaise;
                bulletDamageText.text = bulletData.damageCost.ToString();

                for (int i = 0; i < bulletData.damageUpgradeLevel; i++)
                {
                    bulletDamageImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }
    public void UpgradeBulletSpeed()
    {
        if (bulletData.speedUpgradeLevel < bulletSpeedImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.bullet))
        {
            if (Bank.Instance.goldAmount >= bulletData.speedCost)
            {
                Bank.Instance.DecreaseGold(bulletData.speedCost);

                bulletData.speed += bulletData.speedUpgradeAmount;

                bulletData.speedUpgradeLevel++;

                bulletData.speedCost += bulletData.speedCostRaise;
                bulletSpeedText.text = bulletData.speedCost.ToString();

                for (int i = 0; i < bulletData.speedUpgradeLevel; i++)
                {
                    bulletSpeedImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }
    public void UpgradeBulletFireRate()
    {
        if (bulletData.fireRateUpgradeLevel < bulletFireRateImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.bullet))
        {
            if (Bank.Instance.goldAmount >= bulletData.fireRateCost)
            {
                Bank.Instance.DecreaseGold(bulletData.fireRateCost);

                bulletData.fireRate -= bulletData.fireRateUpgradeAmount;

                bulletData.fireRateUpgradeLevel++;

                bulletData.fireRateCost += bulletData.fireRateCostRaise;
                bulletFireRateText.text = bulletData.fireRateCost.ToString();

                for (int i = 0; i < bulletData.fireRateUpgradeLevel; i++)
                {
                    bulletFireRateImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }



    // METEOR UPGRADES 
    /*
    public void UpgradeMeteorDamage() 
    {
        if (meteorData.damageUpgradeLevel < meteorDamageImages.Length)
        {
            if (Bank.Instance.goldAmount >= meteorData.damageCost)
            {

                Bank.Instance.DecreaseGold(meteorData.damageCost);

                meteorData.damage += meteorData.damageUpgradeAmount;

                meteorData.damageUpgradeLevel++;

                meteorData.damageCost += meteorData.damageCostRaise;
                meteorDamageText.text = meteorData.damageCost.ToString();

                for (int i = 0; i < meteorData.damageUpgradeLevel; i++)
                {
                    meteorDamageImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }
    public void UpgradeMeteorSpawnInterval()
    {

        if (meteorData.spawnIntervalUpgradeLevel < meteorspawnIntervalImages.Length)
        {
            if (Bank.Instance.goldAmount >= meteorData.spawnIntervalCost)
            {

                Bank.Instance.DecreaseGold(meteorData.spawnIntervalCost);

                meteorData.spawnInterval -= meteorData.spawnIntervalUpgradeAmount;

                meteorData.spawnIntervalUpgradeLevel++;

                meteorData.spawnIntervalCost += meteorData.spawnIntervalCostRaise;
                meteorSpawnIntervalText.text = meteorData.spawnIntervalCost.ToString();

                for (int i = 0; i < meteorData.spawnIntervalUpgradeLevel; i++)
                {
                    meteorspawnIntervalImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }

    */


    // MINE UPGRADES

    public void UpgradeMineDamage()
    {
        if (mineData.damageUpgradeLevel < mineDamageImages.Length &&  !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.mine))
        {
            if (Bank.Instance.goldAmount >= mineData.damageCost)
            {

                Bank.Instance.DecreaseGold(mineData.damageCost);

                mineData.damage += mineData.damageUpgradeAmount;

                mineData.damageUpgradeLevel++;

                mineData.damageCost += mineData.damageCostRaise;
                mineDamageText.text = mineData.damageCost.ToString();

                for (int i = 0; i < mineData.damageUpgradeLevel; i++)
                {
                    mineDamageImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
       
    }
    public void UpgradeMineExplosionRadius()
    {
        if (mineData.explosionRadiusUpgradeLevel < mineexplosionRadiusImages.Length && !BuffChoseManagement.Instance.buffList.Contains(BuffChoseManagement.Instance.mine))
        {
            if (Bank.Instance.goldAmount >= mineData.explosionRadiusCost)
            {
                Bank.Instance.DecreaseGold(mineData.explosionRadiusCost);

                mineData.explosionRadius += mineData.explosionRadiusUpgradeAmount;

                mineData.explosionRadiusUpgradeLevel++;

                mineData.explosionRadiusCost += mineData.explosionRadiusCostRaise;
                mineExplosionRadiusText.text = mineData.explosionRadiusCost.ToString();

                for (int i = 0; i < mineData.explosionRadiusUpgradeLevel; i++)
                {
                    mineexplosionRadiusImages[i].color = Color.green;
                }
                PlayerPrefs.SetInt("Gold", Bank.Instance.goldAmount);

            }
        }
        
    }

}
