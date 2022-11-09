using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerHandler : MonoBehaviour
{
    BulletData bulletData;
    PoolPosition poolPosition;

    Transform target;
    public Transform closestTarget = null;
    public Transform parentObject;

    private void Awake()
    {
        poolPosition = FindObjectOfType<PoolPosition>();

        bulletData = GetComponent<BulletData>();

    }
    private void OnEnable()
    {

        transform.position = parentObject.position;

        
        FindClosestTarget();
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(BulletData.Instance.damage);
            gameObject.SetActive(false);
            transform.SetParent(poolPosition.transform);

        }
    }








    // CLOSEST TARGET FIND && MISSILE MOVEMENT
    public void FindClosestTarget()
    {
        StartCoroutine(FindClosestTargetENUM());
    }
    IEnumerator FindClosestTargetENUM()
    {
        while (true)
        {

            EnemyCollisionHandler[] enemies = FindObjectsOfType<EnemyCollisionHandler>();
            float maxDistance = Mathf.Infinity;

            foreach (EnemyCollisionHandler enemy in enemies)
            {

                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);//vector3distance ın ilk degiskenini degistirdim.
                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }
            target = closestTarget;
            // Debug.Log("missile gönderiliyor");

            SendMissile();

            yield return new WaitForSeconds(0.1f);
        }

    }

    void SendMissile() 
    {
        StartCoroutine(MissileMovement(this.gameObject));
    }
    IEnumerator MissileMovement(GameObject createdMissile)
    {
        while (true)
        {

            if (createdMissile != null && closestTarget != null)
            {


               // bulletData = createdMissile.GetComponent<BulletData>();// bulletdata yerine normal speed yazýp optimize edilebilir.
                createdMissile.transform.localPosition += (closestTarget.transform.position - createdMissile.transform.position).normalized * BulletData.Instance.speed * Time.deltaTime;
                createdMissile.transform.LookAt(closestTarget); // lerp ile yapmayý dene.

                Transform temptarget = closestTarget;

                if (temptarget == null)
                {
                    createdMissile.SetActive(false);
                }

            }
            else if (closestTarget == null)
            {
                createdMissile.SetActive(false);

                //FindClosestTarget();
            }

            yield return null;
        }

    }
}
