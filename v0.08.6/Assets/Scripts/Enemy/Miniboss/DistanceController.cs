using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    EnemyCollisionHandler enemyCollisionHandler;
    MiniBoss miniboss;
    MinibossAi minibossAi;
    Transform target;
    public TargetFollow targetFollow;
    
    private void Awake()
    {
        enemyCollisionHandler = GetComponent<EnemyCollisionHandler>();
        target = FindObjectOfType<PlayerData>().transform;
        targetFollow = GetComponent<TargetFollow>();

        miniboss = GetComponent<MiniBoss>();
        minibossAi = GetComponent<MinibossAi>();

    }
    private void OnEnable()
    {
        targetFollow.speed = miniboss.speed;
    }
    private void OnDisable()
    {
        targetFollow.speed = 0;

    }
    private void Update()
    {
        if (enemyCollisionHandler.thisHealth <= 500)
        {
            minibossAi.StartLasergun();
            targetFollow.enabled = false;
            this.enabled = false;
        }
      /*  if (Vector3.Distance(this.transform.position, target.position) < 10f)
        {
            minibossAi.StartLasergun();
            targetFollow.enabled = false;
            this.enabled = false;
        }*/
    }
    
    IEnumerator LasergunCoolDown()
    {
        yield return new WaitForSeconds(20);
    }
}
