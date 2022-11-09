using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAuto : MonoBehaviour
{
    public GameObject[] objectPool;
    private void Start()
    {
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
               // StartCoroutine(SendMissile(tempBullet));


                if (i == objectPool.Length - 1)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(1);

            }
        }
    }





    // CLOSEST TARGET FIND










}
