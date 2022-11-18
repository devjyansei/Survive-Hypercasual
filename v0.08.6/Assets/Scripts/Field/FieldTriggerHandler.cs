using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTriggerHandler : MonoBehaviour
{
    public static FieldTriggerHandler Instance;
    public Coroutine tempDamageCoroutine;
    ParticleSystem shockParticle;
    private void Awake()
    {
        Instance = this;
        shockParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    
    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null) 
            {
                Coroutine tempcor = StartCoroutine(DealDamage(damageable));


                tempDamageCoroutine = tempcor;
                if (other.GetComponent<EnemyCollisionHandler>().thisHealth > 0 && other.GetComponent<IDamageable>() != null) 
                {
                    Debug.Log("ife girdi");
                    other.gameObject.GetComponent<EnemyCollisionHandler>().fieldDamageCoroutine = tempDamageCoroutine;
                }
                else
                {

                    Debug.Log("else e girdi");
                    StopCoroutine(tempDamageCoroutine);
                    tempDamageCoroutine = null;
                }             
            }
            
        }        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {            
            StopCoroutine(other.GetComponent<EnemyCollisionHandler>().fieldDamageCoroutine);          
        }      
    }

    IEnumerator DealDamage(IDamageable damageable)
    {
        while (true)
        {
            damageable.TakeDamage(FieldData.Instance.damage);
            shockParticle.Play(); 
            yield return new WaitForSeconds(FieldData.Instance.hitInterval);
        }
    }
}
