using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int aliveEnemyCount;

    public GameObject enemyPrefab;
    public Transform spawnArea;
    float areaSizeX;
    float areaSizeZ;
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateEnemy();
        }
    }
    void CreateEnemy()
    {
        areaSizeX = spawnArea.GetComponent<BoxCollider>().bounds.extents.x;
        areaSizeZ = spawnArea.GetComponent<BoxCollider>().bounds.extents.z;
        Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

        Instantiate(enemyPrefab,spawnPos,transform.rotation);
        aliveEnemyCount++;

    }


}
