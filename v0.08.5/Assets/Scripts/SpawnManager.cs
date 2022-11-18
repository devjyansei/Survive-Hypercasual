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

    // waves
    public GameObject enemyPrefab;
    public GameObject[] firstWave;
    public GameObject[] secondWave;
    public GameObject[] thirdWave;
    public GameObject[] fourthWave;
    public GameObject[] fifthWave;

    //wave sizes
    public int firstWaveSize;
    public int secondWaveSize;

    public int aliveEnemyCount;
    public int createdEnemyCount;

    //wave monster cooldowns
    public int firstWaveInterval;
    public int secondWaveInterval;
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





    // FIRST WAVE

    
    IEnumerator FirstWaveSpawner()
    {
        while (true)
        {
            
            areaSizeX = spawnArea.GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnArea.GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(firstWave[Random.Range(0, firstWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;
            if (createdEnemyCount >= firstWaveSize)
            {
                StopCoroutine(FirstWaveSpawner());
                CreateSecondWaveEnemys();
                break;
            }

            yield return new WaitForSeconds(firstWaveInterval);
        }


    }

    public void CreateFirstWaveEnemys()
    {
        StartCoroutine(FirstWaveSpawner());               
    }

    // SECOND WAVE
    IEnumerator SecondWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnArea.GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnArea.GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(secondWave[Random.Range(0, firstWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;
            if ((createdEnemyCount-firstWaveSize) >= secondWaveSize)
            {
                StopCoroutine(FirstWaveSpawner());
                break;
            }

            yield return new WaitForSeconds(secondWaveInterval);
        }


    }

    public void CreateSecondWaveEnemys()
    {
        StartCoroutine(SecondWaveSpawner());
    }
}
