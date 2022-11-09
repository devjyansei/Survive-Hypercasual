using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
    public static FieldData Instance;

    Vector3 radius;

    public int damage;
    public float hitInterval;
    public float radiusMultiplier;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {       
        radius = transform.localScale;
    }
    private void Update()
    {
        transform.localScale = radius*radiusMultiplier;
    }
}
