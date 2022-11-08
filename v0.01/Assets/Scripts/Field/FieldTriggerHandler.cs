using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTriggerHandler : MonoBehaviour
{
    
    List<Coroutine> damageCoroutines = new List<Coroutine>();
    public GameObject[] damageTakers; // Set in inspector

    List<int> damageCoroutinesIndex = new List<int>();
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
          
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
           // Debug.Log(damageable);
            if (damageable != null && damageTakers[damageTakers.Length -1] == null) // damageable ise  &&  damagetakers son indexi boþsa
            {
                Coroutine tempDamageCoroutine = StartCoroutine(DealDamage(damageable));
                damageCoroutines.Add(tempDamageCoroutine); 
               
                damageTakers[damageCoroutines.IndexOf(tempDamageCoroutine)] = other.gameObject; //damagetakers ve coroutine indexi esitledim

                
            }

        }
        //damageCoroutines.IndexOf(tempDamageCoroutine); // 0.index

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
        }
        
    }

    IEnumerator DealDamage(IDamageable damageable)
    {
        while (true)
        {            
            damageable.TakeDamage(FieldData.Instance.damage);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
