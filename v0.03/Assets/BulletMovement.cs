using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    Transform target;
    public Transform closestTarget = null;



    private void OnEnable()
    {
        FindClosestTarget();
        Debug.Log(target);
    }


    
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

            yield return new WaitForSeconds(2f);
            Debug.Log("new target : " + target);
        }

    }
}
