using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAutomatic : MonoBehaviour
{
    public GameObject meteorPrefab;
    


    private void Start()
    {
        StartCoroutine(CreateMeteor());

    }
    Vector3 GenerateRandomPosition()
    {
        float randomPosX = Random.Range(-MeteorData.Instance.spawnRadius, MeteorData.Instance.spawnRadius);
        float randomPosZ = Random.Range(-MeteorData.Instance.spawnRadius, MeteorData.Instance.spawnRadius);

        Vector3 randomSpawnPosition = new Vector3(randomPosX, transform.position.y, randomPosZ);
        return randomSpawnPosition;
    }

    IEnumerator CreateMeteor()
    {
        while (true)
        {
            GameObject tempMeteor = Instantiate(meteorPrefab);
            
            tempMeteor.transform.position = PlayerData.Instance.transform.position+GenerateRandomPosition();
            tempMeteor.GetComponent<Rigidbody>().AddForce(0,-MeteorData.Instance.forcePower,0,ForceMode.Impulse);
            
            yield return new WaitForSeconds(MeteorData.Instance.spawnInterval);
        }


    }
}
