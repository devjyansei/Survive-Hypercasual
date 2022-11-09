using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAuto : MonoBehaviour
{
    BulletData bulletData;
    public SpawnManager spawnManager;
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
                yield return new WaitUntil(() => spawnManager.aliveEnemyCount > 0); // enemycount 0 dan buyuk olana kadar bekle

                objectPool[i].SetActive(true);
                GameObject tempBullet = objectPool[i];

                if (i == objectPool.Length - 1)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(BulletData.Instance.fireRate);

            }

        }
    }





    // CLOSEST TARGET FIND










}
