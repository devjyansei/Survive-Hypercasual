using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour,IDamageable,IKillable
{
    //enemy turettikce buraya ekle.
    Coroutine damageCoroutine;
    bool isThatStalker;
    bool isThatTanky;
    Stalker stalker;
    Tanky tanky;
    private void Awake()
    {
        if (GetComponent<Stalker>() != null)
        {
            stalker = GetComponent<Stalker>();

            isThatStalker = true;
        }
        else if (GetComponent<Tanky>() != null)
        {
            tanky = GetComponent<Tanky>();

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
    private void OnTriggerEnter(Collider other)
    {
        
        if (isThatStalker)
        {
            if (stalker.health <= 0)
            {
                Destroy(stalker.gameObject);
                //onstalkerdeath(patlama ozelligi)
            }           
        }
        else if (isThatTanky)
        {
            if (tanky.health <= 0)
            {
                Destroy(tanky.gameObject);
                //ontankydeath
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
                damageable.TakeDamage(stalker.damage);
            }
            else if (isThatTanky)
            {
                damageable.TakeDamage(tanky.damage);
            }
            yield return new WaitForSeconds(1);
        }
    }


    public void OnDamageTaken(int amount)
    {
        if (isThatStalker)
        {
            stalker.health -= amount;
        }
        else if (isThatTanky)
        {
            tanky.health -= amount;
        }
    }
    
    public void OnKill()
    {
        Destroy(gameObject);
    }




    // INTERFACES
    public void TakeDamage(int amount) // interface
    {
        OnDamageTaken(amount);
    }

    public void Kill()
    {
        OnKill();
    }
    
}
