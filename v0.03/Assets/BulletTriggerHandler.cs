using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerHandler : MonoBehaviour
{
    BulletData bulletData;
    private void Awake()
    {
        bulletData = GetComponent<BulletData>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(bulletData.damage);
            Destroy(gameObject);
        }
    }
}
