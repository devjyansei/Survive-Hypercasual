using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAuto : MonoBehaviour
{
    BulletData bulletData;
    public GameObject bulletPrefab;

    public float speed = 5;
    Transform target;
    public Transform closestTarget = null;

    public GameObject[] objectPool;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        FindClosestTarget();
        StartCoroutine(CreateMissile());
    }

    IEnumerator CreateMissile()
    {
        while (true)
        {
            for (int i = 0; i < objectPool.Length; i++)
            {
                objectPool[i].SetActive(true);
                GameObject tempBullet = objectPool[i];
                // tempBullet.transform.position = transform.parent.position;
                StartCoroutine(SendMissile(tempBullet));
                if (i == objectPool.Length-1)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(1);
               
            }

        }

    }

    IEnumerator SendMissile(GameObject createdMissile)
    {
        while (true)
        {

            if (createdMissile != null && closestTarget != null)
            {
                bulletData = createdMissile.GetComponent<BulletData>();// bulletdata yerine normal speed yazýp optimize edilebilir.
                createdMissile.transform.localPosition += (closestTarget.transform.position - createdMissile.transform.position).normalized * bulletData.speed * Time.deltaTime;
                createdMissile.transform.LookAt(closestTarget); // lerp ile yapmayý dene.               
            }
            else if(closestTarget == null)
            {
                FindClosestTarget();
                if (closestTarget == null)
                {
                   createdMissile.SetActive(false);
                   // disabledMissile = createdMissile;
                }
            }
                       
            yield return null;
        }

    }



    // CLOSEST TARGET FIND

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
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.transform;
                    maxDistance = targetDistance;
                }
            }
            target = closestTarget;

            yield return new WaitForSeconds(1f);
            Debug.Log("new target : " + target);
        }

    }






        
    
}
