using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
    public static FieldData Instance;

    Vector3 radius;

    //FIELD UPGRADES
    public int damage; // 10 DAN BASLAYIP 5ER 5ER ARTACAK.
    public float hitInterval; // 1 DEN BASLAYIP 0.25  E KADAR DÜSECEK. HER DÜÞÜÞ 0.25F
    public float radiusMultiplier; // 3 TEN BASLAYIP 5E CIKACAK. HER YUKSELTME 0.50

    private void Awake()
    {
        Instance = this;       
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
