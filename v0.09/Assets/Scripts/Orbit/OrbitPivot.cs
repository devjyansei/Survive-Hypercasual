using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPivot : MonoBehaviour
{
    [SerializeField] PlayerData player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
