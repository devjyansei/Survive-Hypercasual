using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour,IDamageable
{
    //enemy turettikce buraya ekle.
    Coroutine damageCoroutine;

    public int thisHealth; // inspectorde görunun health budeðil. startta aldýgýmýz health inspectorde görunen.
    public int thisDamage;
    public float thisAttackSpeed;

    bool isThatStalker;
    bool isThatTanky;
    Stalker stalker;
    Tanky tanky;

    public Coroutine fieldDamageCoroutine; // fieldTriggerHandler ýn alanýna girdiginde calisan coroutine buna atanir.
    public Coroutine orbitDamageCoroutine;

    private void Awake()
    {
        if (GetComponent<Stalker>() != null)
        {
            stalker = GetComponent<Stalker>();

            thisHealth = stalker.health;
            thisDamage = stalker.damage;
            thisAttackSpeed = stalker.attackSpeed;

            isThatStalker = true;
        }
        else if (GetComponent<Tanky>() != null)
        {
            tanky = GetComponent<Tanky>();

            thisHealth = tanky.health;
            thisDamage = tanky.damage;
            thisAttackSpeed = tanky.attackSpeed;

            isThatTanky = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageCoroutine =  StartCoroutine(DealDamage(damageable));
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

    IEnumerator DealDamage(IDamageable damageable)
    {
        while (true)
        {
            //damageable.TakeDamage(EnemyData.Instance.damage);
            if (isThatStalker)
            {
                damageable.TakeDamage(thisDamage);
            }
            else if (isThatTanky)
            {
                damageable.TakeDamage(thisDamage);
            }
            yield return new WaitForSeconds(thisAttackSpeed);
        }
    }

       
    public void OnDamageTaken(int amount)
    {
        thisHealth -= amount;
        Debug.Log("enemyhealth : " + thisHealth);
        if (thisHealth <= 0)
        {
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
