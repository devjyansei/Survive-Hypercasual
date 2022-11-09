using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerHandler : MonoBehaviour
{
    MissileAuto missileAuto;
    BulletData bulletData;
    PoolPosition poolPosition;
    private void Awake()
    {
        poolPosition = FindObjectOfType<PoolPosition>();
        missileAuto = FindObjectOfType<MissileAuto>();
        bulletData = GetComponent<BulletData>();
    }
    private void OnEnable()
    {
        transform.position = transform.parent.position;
        missileAuto.FindClosestTarget();
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(bulletData.damage);
            gameObject.SetActive(false);
            transform.SetParent(poolPosition.transform);

        }
    }
}
