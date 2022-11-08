using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCollisionHandler : MonoBehaviour
{
    Coroutine damageCoroutine;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {           
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageCoroutine = StartCoroutine(DealDamage(damageable));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator DealDamage(IDamageable damageable)
    {
        while (true)
        {
            damageable.TakeDamage(OrbitData.Instance.damage);
            
            yield return new WaitForSeconds(1);
        }
    }

}
