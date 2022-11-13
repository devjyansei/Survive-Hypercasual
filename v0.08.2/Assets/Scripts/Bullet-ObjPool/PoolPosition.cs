using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPosition : MonoBehaviour
{
    PlayerData playerData;
    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }
    void Update()
    {
        transform.position = playerData.transform.position;
    }
}
