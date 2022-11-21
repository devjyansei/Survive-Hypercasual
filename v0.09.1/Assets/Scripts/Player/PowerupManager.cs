using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance;

    PlayerData playerData;
    public HypercasualMovement hypercasualMovement;
    public OrbitData orbitData;
    public BulletData bulletData;
    public MineData mineData;
    public FieldData fieldData;

    [Header("Powerup Cooldowns")]
    public float damagePowerupCooldown;
    public float defencePowerupCooldown;
    public float speedPowerupCooldown;

    [Header("Powerup Magnitudes")]
    public int damagePowerupMagnitude;// percentage
    public int defencePowerupMagnitude;// amount
    public float speedPowerupMagnitude;// amount




    private void Awake()
    {
        Instance = this;
        playerData = GetComponent<PlayerData>();
    }



    public void StartDamagePowerupCooldown()
    {
        StartCoroutine(DamagePowerupCooldown());
    }
    public void StartDefencePowerupCooldown()
    {
        StartCoroutine(DefencePowerupCooldown());
    }
    public void StartSpeedPowerupCooldown()
    {
        StartCoroutine(SpeedPowerupCooldown());
    }

    IEnumerator DamagePowerupCooldown()
    {
        float orjOrbitDamage = orbitData.damage;
        orbitData.damage += (orbitData.damage / 100) * damagePowerupMagnitude;

        float orjBulletDamage = bulletData.damage;
        bulletData.damage += (bulletData.damage / 100) * damagePowerupMagnitude;

        float orjMineDamage = mineData.damage;
        mineData.damage += (mineData.damage / 100) * damagePowerupMagnitude;

        float orjFieldDamage = fieldData.damage;
        fieldData.damage += (fieldData.damage / 100) * damagePowerupMagnitude;

        yield return new WaitForSeconds(damagePowerupCooldown);

        orbitData.damage = orjOrbitDamage;
        bulletData.damage = orjBulletDamage;
        mineData.damage = orjMineDamage;
        fieldData.damage = orjFieldDamage;

        PlayerCollisionHandler.Instance.canCollectDamagePowerup = true;
    }
    IEnumerator DefencePowerupCooldown()
    {
        playerData.defence += defencePowerupMagnitude;
        yield return new WaitForSeconds(defencePowerupCooldown);
        playerData.defence -= defencePowerupMagnitude;

        PlayerCollisionHandler.Instance.canCollectDefencePowerup = true;

    }
    IEnumerator SpeedPowerupCooldown()
    {
        hypercasualMovement.speed += speedPowerupMagnitude;
        yield return new WaitForSeconds(speedPowerupCooldown);
        hypercasualMovement.speed -= speedPowerupMagnitude;

        PlayerCollisionHandler.Instance.canCollectSpeedPowerup = true;
    }

   
}
