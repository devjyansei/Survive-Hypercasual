using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
    public static FieldData Instance;
    public int damage;
    public int enemyHoldAmount;

    private void Awake()
    {
        Instance = this;
    }
}
