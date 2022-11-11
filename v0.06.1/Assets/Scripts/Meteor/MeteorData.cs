using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorData : MonoBehaviour
{
    public static MeteorData Instance;

    // METEOR UPGRADES
    public int damage; // 40 - 80 - 120 - 160
    public float spawnInterval; // 1 - 0.9 - 0.8 - 0.7 - 0.6 - 0.5


    // size sabit kalsýn
    public float size; 
    // meteorauto kullanýyor
    public int spawnRadius;

    // sadece gelistirme için
    public float forcePower;

    private void Awake()
    {
        Instance = this;
    }

    // size ile scale oranla.

}
