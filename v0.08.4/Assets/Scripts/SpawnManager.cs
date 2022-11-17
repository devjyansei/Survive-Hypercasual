using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    // spawn
    public Transform spawnArea;
    float areaSizeX;
    float areaSizeZ;

    // mobs
    public int aliveEnemyCount;
    public GameObject enemyPrefab;
    public GameObject[] firstWave;
    public GameObject[] secondWave;
    public GameObject[] thirdWave;
    public GameObject[] fourthWave;
    public GameObject[] fivethWave;

    private void Awake()
    {
        Instance = this;
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
    IEnumerator EnemyGenerator()
    {
        CreateEnemy();


        yield return new WaitForSeconds(2);
    }



    public void StartEnemyGenerator()
    {
        StartCoroutine(EnemyGenerator());
    }



    public void StartFirstWave()
    {
        StartCoroutine(FirstWaveSpawner());
    }
    IEnumerator FirstWaveSpawner()
    {
        CreateFirstWaveEnemys();
        yield return new WaitForSeconds(2);

    }
    public void CreateFirstWaveEnemys()
    {
        areaSizeX = spawnArea.GetComponent<BoxCollider>().bounds.extents.x;
        areaSizeZ = spawnArea.GetComponent<BoxCollider>().bounds.extents.z;
        Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

        Instantiate(firstWave[Random.Range(0, firstWave.Length)], spawnPos, transform.rotation);
        aliveEnemyCount++;
    }
}
