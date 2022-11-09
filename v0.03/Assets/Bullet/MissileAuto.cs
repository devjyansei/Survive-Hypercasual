using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAuto : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float speed = 5;
    Transform target;
    public Transform closestTarget = null;

    private void OnEnable()
    {
        FindClosestTarget();
        StartCoroutine(CreateMissile(bulletPrefab));
    }
    private void OnDisable()
    {
        
    }

    IEnumerator CreateMissile(GameObject bullet)
    {
        while (true)
        {
            GameObject tempBullet = Instantiate(bulletPrefab);
            tempBullet.transform.position = transform.parent.position;

            StartCoroutine(SendMissile(tempBullet));
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator SendMissile(GameObject createdMissile)
    {
        while (true)
        {

            if (createdMissile != null && closestTarget != null)
            {
                createdMissile.transform.position += (closestTarget.transform.position - createdMissile.transform.position).normalized * speed * Time.deltaTime;
                createdMissile.transform.LookAt(closestTarget); // lerp ile yapmayý dene.
               
               /* float gap = Vector3.Distance(createdMissile.transform.position, closestTarget.transform.position);
                if (gap < 1f)
                {
                    Debug.Log("yaklastý");
                }*/

            }
            else if(closestTarget == null)
            {
                FindClosestTarget();
                if (closestTarget == null)
                {
                    Destroy(createdMissile);
                }
            }
            
            

            yield return null;
        }

    }






    // CLOSEST TARGET FIND

    void FindClosestTarget()
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
