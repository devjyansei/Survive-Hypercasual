using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour,IDamageable
{
    public PlayerCollisionHandler playerCollisionHandler;
    public PlayerData playerData;


    //enemy turettikce buraya ekle.
    public Coroutine damageCoroutine;

    public int thisHealth; // inspectorde g?runen health bu de?il. startta ald?g?m?z health inspectorde g?runen.
    public int thisDamage;
    public float thisAttackSpeed;
    public int thisGoldReward;
    public int thisScoreReward;

    Stalker stalker;
    Tanky tanky;
    WeakMinion weakMinion;

    public Coroutine fieldDamageCoroutine; // fieldTriggerHandler ?n alan?na girdiginde calisan coroutine buna atanir.
    public Coroutine orbitDamageCoroutine;

    private void Awake()
    {
        if (GetComponent<Stalker>() != null)
        {
            stalker = GetComponent<Stalker>();

            thisHealth = stalker.health;
            thisDamage = stalker.damage;
            thisAttackSpeed = stalker.attackSpeed;
            thisGoldReward = stalker.goldReward;
            thisScoreReward = stalker.scoreReward;

        }
        else if (GetComponent<Tanky>() != null)
        {
            tanky = GetComponent<Tanky>();

            thisHealth = tanky.health;
            thisDamage = tanky.damage;
            thisAttackSpeed = tanky.attackSpeed;
            thisGoldReward = tanky.goldReward;
            thisScoreReward = tanky.scoreReward;

        }
        else if (GetComponent<WeakMinion>() != null)
        {
            weakMinion = GetComponent<WeakMinion>();

            thisHealth = weakMinion.health;
            thisDamage = weakMinion.damage;
            thisAttackSpeed = weakMinion.attackSpeed;
            thisGoldReward = weakMinion.goldReward;
            thisScoreReward = weakMinion.scoreReward;

        }
    }
    private void Start()
    {
        playerCollisionHandler = FindObjectOfType<PlayerCollisionHandler>();
        playerData = FindObjectOfType<PlayerData>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageCoroutine = StartCoroutine(DealDamage(damageable));
            }
            
            
        }
        
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Particle"))
        {
            TakeDamage(MineData.Instance.damage);
        }
    }
   
    IEnumerator DealDamage(IDamageable damageable)
    {
        if (damageable != null)
        {
            while (true)
            {
                if (damageable != null)
                {
                    damageable.TakeDamage(thisDamage);
                                       
                }
               

                yield return new WaitForSeconds(thisAttackSpeed);
            }
        }
        
        
    }
    public void StopDamageCoroutines() 
    {
        StopCoroutine(damageCoroutine);
    }
       
    public void OnDamageTaken(int amount)
    {
        thisHealth -= amount;
        if (thisHealth <= 0 )
        {
            
            Bank.Instance.IncreaseGold(thisGoldReward);
            PlayerData.Instance.score += thisScoreReward;
            playerCollisionHandler.damageDealers.Remove(this);
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }


    // ---------------- INTERFACES ---------------- //
    public void TakeDamage(int amount) // interface
    {
        if (thisHealth > 0)
        {
            OnDamageTaken(amount);
        }
    }


}
