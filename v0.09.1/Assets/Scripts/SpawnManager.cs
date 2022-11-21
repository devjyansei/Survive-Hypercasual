using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [Header("INFO")]
    public int aliveEnemyCount;
    public int createdEnemyCount;
    // spawn
    public Transform[] spawnAreas;

    float areaLeftBound;
    float areaRightBound;
    float areaTopBound;
    float areaBottomBound;



    float areaSizeX;
    float areaSizeZ;

    // waves
    [Header("WAVES")]
    public GameObject enemyPrefab;
    public GameObject[] firstWave;
    public GameObject[] secondWave;
    public GameObject[] thirdWave;
    public GameObject[] fourthWave;
    public GameObject[] fifthWave;
    public GameObject[] sixthWave;

    /*
    public GameObject[] seventhhWave;
    public GameObject[] eighthWave;
    public GameObject[] ninethWave;
    public GameObject[] tenthWave;*/

    //wave sizes
    [Header("WAVE SIZES")]
    public int firstWaveSize;
    public int secondWaveSize;
    public int thirdWaveSize;
    public int fourthWaveSize;
    public int fifthhWaveSize;
    public int sixthWaveSize;

  /*
    public int seventhhWaveSize;
    public int eighthWaveSize;
    public int ninethWaveSize;
    public int tenthWaveSize;*/


    //wave monster cooldowns
    [Header("SPAWN INTERVALS")]
    public float firstWaveInterval;
    public float secondWaveInterval;
    public float thirdWaveInterval;
    public float fourthWaveInterval;
    public float fifthWaveInterval;
    public float sixthWaveInterval;
    /*
    public int seventhWaveInterval;
    public int eighthWaveInterval;
    public int ninethWaveInterval;
    public int tenthWaveInterval;*/

    bool firstWaveSpawned;
    bool secondWaveSpawned;
    bool thirdWaveSpawned;
    bool fourthWaveSpawned;
    bool fifthWaveSpawned;
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

        if (Time.time >= 2 && firstWaveSpawned == false)
        {
            firstWaveSpawned = true;
            CreateFirstWaveEnemys();
            Debug.Log("time 3ü geçti");
        }
        if (Time.time >= 8 && secondWaveSpawned == false)
        {
            UiManager.Instance.OpenChoseOneCanvas();
            secondWaveSpawned = true;
            CreateSecondWaveEnemys();
            Debug.Log("time 15i geçti");
        }
        if (Time.time >= 16 && thirdWaveSpawned == false)
        {
            UiManager.Instance.OpenChoseOneCanvas();

            thirdWaveSpawned = true;
            CreateThirdWaveEnemys();
            Debug.Log("time 15i geçti");
        }
        if (Time.time >= 30 && fourthWaveSpawned == false)
        {
            UiManager.Instance.OpenChoseOneCanvas();

            fourthWaveSpawned = true;
            CreateFourthWaveEnemys();
            Debug.Log("time 15i geçti");
        }
        if (Time.time >= 250 && fifthWaveSpawned == false)
        {
            fifthWaveSpawned = true;
            CreateFifthWaveEnemys();
            Debug.Log("time 15i geçti");
        }
    }

    void CreateEnemy()
    {
        areaSizeX = spawnAreas[Random.Range(0,spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
        areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
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





    // --------------------FIRST WAVE--------------------


    IEnumerator FirstWaveSpawner()
    {
        while (true)
        {
             int randomArea = Random.Range(0, spawnAreas.Length);
            //int randomArea = 0;
            

            areaLeftBound = spawnAreas[randomArea].GetComponent<BoxCollider>().bounds.min.x;
            areaRightBound = spawnAreas[randomArea].GetComponent<BoxCollider>().bounds.max.x;
            areaBottomBound = spawnAreas[randomArea].GetComponent<BoxCollider>().bounds.min.z;
            areaTopBound = spawnAreas[randomArea].GetComponent<BoxCollider>().bounds.max.z;

            areaSizeX = spawnAreas[randomArea].position.z - (spawnAreas[randomArea].GetComponent<BoxCollider>().bounds.size.z / 2);


            Vector3 spawnPos = new Vector3(Random.Range(areaLeftBound, areaRightBound), 1, Random.Range(areaBottomBound, areaTopBound));

            Instantiate(firstWave[Random.Range(0, firstWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;
            if (createdEnemyCount >= firstWaveSize)
            {
                StopCoroutine(FirstWaveSpawner());
                //CreateSecondWaveEnemys();
                break;
            }

            yield return new WaitForSeconds(firstWaveInterval);
        }


    }

    public void CreateFirstWaveEnemys()
    {
        StartCoroutine(FirstWaveSpawner());               
    }

    // --------------------SECOND WAVE--------------------
    IEnumerator SecondWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(secondWave[Random.Range(0, firstWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;
            if ((createdEnemyCount-firstWaveSize) >= secondWaveSize)
            {
                StopCoroutine(FirstWaveSpawner());
                //CreateThirdWaveEnemys();
                break;
            }

            yield return new WaitForSeconds(secondWaveInterval);
        }


    }

    public void CreateSecondWaveEnemys()
    {
        StartCoroutine(SecondWaveSpawner());
    }

    // --------------------THIRD WAVE--------------------


    IEnumerator ThirdWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(thirdWave[Random.Range(0, thirdWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;

            if ((createdEnemyCount - firstWaveSize - secondWaveSize) >= thirdWaveSize)
            {
                StopCoroutine(ThirdWaveSpawner());
                //CreateFourthWaveEnemys();
                break;
            }
            yield return new WaitForSeconds(thirdWaveInterval);

        }


    }

    public void CreateThirdWaveEnemys()
    {
        StartCoroutine(ThirdWaveSpawner());
    }



    // --------------------FOURTH WAVE--------------------


    IEnumerator FourthWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(fourthWave[Random.Range(0, thirdWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;

            if ((createdEnemyCount - firstWaveSize - secondWaveSize - thirdWaveSize) >= fourthWaveSize)
            {
                StopCoroutine(FourthWaveSpawner());
               // CreateFifthWaveEnemys();
                break;
            }
            yield return new WaitForSeconds(fourthWaveInterval);

        }


    }

    public void CreateFourthWaveEnemys()
    {
        StartCoroutine(FourthWaveSpawner());
    }


    // --------------------FIFTH WAVE--------------------


    IEnumerator FifthWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(fifthWave[Random.Range(0, thirdWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;

            if ((createdEnemyCount - firstWaveSize - secondWaveSize - thirdWaveSize-fourthWaveSize) >= fifthhWaveSize)
            {
                StopCoroutine(FifthWaveSpawner());
                //CreateSixthWaveEnemys();
                break;
            }
            yield return new WaitForSeconds(fifthWaveInterval);

        }


    }

    public void CreateFifthWaveEnemys()
    {
        StartCoroutine(FifthWaveSpawner());
    }
    
    
    // --------------------SIXTH WAVE--------------------


    IEnumerator SixthWaveSpawner()
    {
        while (true)
        {

            areaSizeX = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.x;
            areaSizeZ = spawnAreas[Random.Range(0, spawnAreas.Length)].GetComponent<BoxCollider>().bounds.extents.z;
            Vector3 spawnPos = new Vector3(Random.Range(-areaSizeX, areaSizeX), 1, Random.Range(-areaSizeZ, areaSizeZ));

            Instantiate(sixthWave[Random.Range(0, thirdWave.Length)], spawnPos, transform.rotation);

            createdEnemyCount++;
            aliveEnemyCount++;

            if ((createdEnemyCount - firstWaveSize - secondWaveSize - thirdWaveSize-fourthWaveSize-fifthhWaveSize) >= sixthWaveSize)
            {
                StopCoroutine(SixthWaveSpawner());
                CreateSixthWaveEnemys();
                break;
            }
            yield return new WaitForSeconds(fifthWaveInterval);

        }


    }

    public void CreateSixthWaveEnemys()
    {
        StartCoroutine(FifthWaveSpawner());
    }
}
