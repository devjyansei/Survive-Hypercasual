using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    Transform target;
    int speed;

    bool isThatStalker;
    bool isThatTanky;
    bool isThatWeakMinion;
    Stalker stalker;
    Tanky tanky;
    WeakMinion weakMinion;
    private void Awake()
    {
        CheckEnemyType();
    }
    private void Start()
    {
        target = FindObjectOfType<PlayerData>().transform;

        if (isThatStalker)
        {
            speed = stalker.speed;
        }
        else if (isThatTanky)
        {
            speed = tanky.speed;
        }
        else if (isThatWeakMinion)
        {
            speed = weakMinion.speed;
        }
    }



    void CheckEnemyType()
    {
        if (GetComponent<Stalker>() != null)
        {
            stalker = GetComponent<Stalker>();

            isThatStalker = true;
        }
        else if (GetComponent<Tanky>() != null)
        {
            tanky = GetComponent<Tanky>();

            isThatTanky = true;
        }
        else if (GetComponent<WeakMinion>() != null)
        {
            weakMinion = GetComponent<WeakMinion>();

            isThatWeakMinion = true;
        }
    }
    private void Update()
    {
        LookTarget();
        Move();

    }
    
    void LookTarget()
    {
        transform.LookAt(target);

    }
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
     
}
