using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    Transform target;
    public int speed;

    bool isThatStalker;
    bool isThatTanky;
    bool isThatWeakMinion;
    bool isThatMiniBoss;
    Stalker stalker;
    Tanky tanky;
    WeakMinion weakMinion;
    MiniBoss miniboss;
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
        else if (isThatMiniBoss)
        {
            speed = miniboss.speed;
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
        else if (GetComponent<MiniBoss>() != null)
        {
            miniboss = GetComponent<MiniBoss>();

            isThatMiniBoss = true;
        }
    }
    private void Update()
    {
        Move();
        LookTarget();

       
    }
    
    void LookTarget()
    {
        transform.LookAt(target);

    }
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void LookTargetWithLerp()
    {
        //transform.LookAt(Vector3.Lerp(transform.position, target.position, 5f));
       // Quaternion.Lerp(transform.rotation, target.rotation, 0.5f);

    }
}
