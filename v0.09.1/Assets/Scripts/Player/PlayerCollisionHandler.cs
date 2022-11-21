using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour,IDamageable
{
    public static PlayerCollisionHandler Instance;

    public List<EnemyCollisionHandler> damageDealers = new List<EnemyCollisionHandler>();
    public PlayerData playerData;
    public GameManager gameManager;

    public bool canCollectDamagePowerup = true;
    public bool canCollectDefencePowerup = true;
    public bool canCollectSpeedPowerup = true;
    private void Awake()
    {
        Instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            if (other.gameObject.GetComponent<DamagePowerup>() != null && canCollectDamagePowerup)
            {
                canCollectDamagePowerup = false;
                Destroy(other.gameObject);
                PowerupManager.Instance.StartDamagePowerupCooldown();
                
            }
            else if (other.gameObject.GetComponent<DefencePowerup>() != null && canCollectDefencePowerup)
            {
                canCollectDefencePowerup = false;
                Destroy(other.gameObject);
                PowerupManager.Instance.StartDefencePowerupCooldown();
            }
            else if (other.gameObject.GetComponent<SpeedPowerup>() != null && canCollectSpeedPowerup)
            {
                canCollectSpeedPowerup = false;
                Destroy(other.gameObject);
                PowerupManager.Instance.StartSpeedPowerupCooldown();
            }
            else
            {
                return;
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            if (other.gameObject.GetComponent<Orbit>() != null)
            {
                other.gameObject.SetActive(false);
                BuffChoseManagement.Instance.OrbitCollected();
                BuffChoseManagement.Instance.buffList.Remove(BuffChoseManagement.Instance.orbit);
            }
            else if (other.gameObject.GetComponent<Bullet>() != null)
            {
                other.gameObject.SetActive(false);
                BuffChoseManagement.Instance.BulletCollected();
                BuffChoseManagement.Instance.buffList.Remove(BuffChoseManagement.Instance.bullet);

            }
            else if (other.gameObject.GetComponent<Mine>() != null)
            {
                other.gameObject.SetActive(false);
                BuffChoseManagement.Instance.MineCollected();
                BuffChoseManagement.Instance.buffList.Remove(BuffChoseManagement.Instance.mine);

            }
            else if (other.gameObject.GetComponent<Field>() != null)
            {
                other.gameObject.SetActive(false);
                BuffChoseManagement.Instance.FieldCollected();
                BuffChoseManagement.Instance.buffList.Remove(BuffChoseManagement.Instance.field);

            }
        }
    }
    */



    void OnDamageTaken(int amount)
    {
        playerData.health -= ReduceDamage(amount);       

        if (playerData.health <= 0)
        {

            foreach (EnemyCollisionHandler enemy in damageDealers)
            {
                Destroy(enemy);
            }
          
            gameManager.GameOver();
        }
    }

    // INTERFACES
    public void TakeDamage(int amount)
    {
        OnDamageTaken(amount);
    }
    void ondie()
    {
        // gameover ekraný
        //highscore yazdýr.
        // tekrar oyna yada reklam izle ve diril.
        // score sýfýrla
    }
    int ReduceDamage(int amount)
    {
        int reducedDamage = amount - playerData.defence;
        return reducedDamage;
    }
}
