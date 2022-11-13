using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAuto : MonoBehaviour
{
    public GameObject minePrefab;
    public PlayerData playerData;
    public GameObject[] minePool;


    private void Start()
    {
        StartCoroutine(CreateMine());
        
    }
    IEnumerator CreateMine()
    {
        while (true)
        {

            for (int i = 0; i < minePool.Length; i++)
            {
                Vector3 tempMinePos = playerData.transform.position + new Vector3(0,-1,0);
                yield return new WaitForSeconds(MineData.Instance.player_Mine_Distance); // mayýn kac saniyelik sure arkamizda olusacak

                GameObject tempMine = minePool[i].gameObject;
                tempMine.SetActive(true);
                tempMine.transform.position = tempMinePos;

                yield return new WaitForSeconds(MineData.Instance.detonateDelay);// patlayana kadar gecen sure
                tempMine.GetComponent<MeshRenderer>().enabled = false;

                yield return new WaitForSeconds(1); // kac saniye patlama kalacak : FÝX kalacak
                tempMine.SetActive(false);

            }
           
        }

    }
}
