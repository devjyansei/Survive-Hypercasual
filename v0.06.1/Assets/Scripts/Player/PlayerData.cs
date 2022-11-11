using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int health;
    public int damage;
    private void Awake()
    {
        Instance = this;
    }
}
