using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPivot : MonoBehaviour
{
    [SerializeField] PlayerData player;

    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
