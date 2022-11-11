using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTriggerHandler : MonoBehaviour
{
    public static FieldTriggerHandler Instance;

    
    public GameObject[] damageTakers; // field'in hasar verebilecegi enemylerin listesi.inspectorden sayisini ayarla.

    private void Awake()
    {
        Instance = this;       
    }
    
    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null) 
            {
                Coroutine tempDamageCoroutine = StartCoroutine(DealDamage(damageable));
                if(other.GetComponent<EnemyCollisionHandler>().thisHealth > 0)
                {                   
                    other.gameObject.GetComponent<EnemyCollisionHandler>().fieldDamageCoroutine = tempDamageCoroutine;
                }
                else
                {
                    StopCoroutine(tempDamageCoroutine);
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
            yield return new WaitForSeconds(FieldData.Instance.hitInterval);
        }
    }
}
