using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour,IDamageable
{
    void OnDamageTaken(int amount)
    {
        PlayerData.Instance.health -= amount;
    }

    // INTERFACES
    public void TakeDamage(int amount)
    {
        OnDamageTaken(amount);
    }

}
