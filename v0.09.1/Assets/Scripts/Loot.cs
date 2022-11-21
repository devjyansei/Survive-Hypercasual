using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject damageBuff;
    public GameObject defenceBuff;
    public GameObject speedBuff;
    public Vector3 dropPosition;

    public List<GameObject> dropList = new List<GameObject>();
    private void Awake()
    {
        dropList.Add(damageBuff);
        dropList.Add(defenceBuff);
        dropList.Add(speedBuff);

    }
    public void CheckItemChance(Vector3 position)
    {
        dropPosition = position;

        int number = Random.Range(0, 100);
        if (number < 2) // 2% þans
        {
            DropItem();
        }
    }
    public void DropItem()
    {
        int index = Random.Range(0,dropList.Count);
        GameObject tempObj =  Instantiate(dropList[index].gameObject);
        tempObj.transform.position = dropPosition + new Vector3(0,-0.5f,0);
    }

}
