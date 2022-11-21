using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;


    public float maxHealth;
    public float health;
    public int damage;
    public int defence;
    public int score;

   

    public Vector3 startPos;
    private void Awake()
    {
        Instance = this;
    }

   

   
   
}
