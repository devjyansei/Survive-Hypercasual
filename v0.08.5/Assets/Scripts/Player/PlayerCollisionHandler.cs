using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour,IDamageable
{
    public static PlayerCollisionHandler Instance;

    public List<EnemyCollisionHandler> damageDealers = new List<EnemyCollisionHandler>();
    public PlayerData playerData;
    public GameManager gameManager;
    private void Awake()
    {
        Instance = this;
    }
    void OnDamageTaken(int amount)
    {
        playerData.health -= amount;

        if (playerData.health <= 0)
        {

            foreach (EnemyCollisionHandler enemy in damageDealers)
            {
                Destroy(enemy);
            }
          
            gameManager.GameOver();
        }
    }

    // INTERFACES
    public void TakeDamage(int amount)
    {
        OnDamageTaken(amount);
    }
    void ondie()
    {
        // gameover ekraný
        //highscore yazdýr.
        // tekrar oyna yada reklam izle ve diril.
        // score sýfýrla
    }
   
}
