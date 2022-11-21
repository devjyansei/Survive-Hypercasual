using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyCollisionHandler : MonoBehaviour,IDamageable
{
    public PlayerCollisionHandler playerCollisionHandler;
    public PlayerData playerData;
    Loot loot;
    Animator damageAnim;

    //enemy turettikce buraya ekle.
    public Coroutine damageCoroutine;

    public int thisHealth; // inspectorde görunen health bu deðil. startta aldýgýmýz health inspectorde görunen.
    public int thisDamage;
    public float thisAttackSpeed;
    public int thisGoldReward;
    public int thisScoreReward;

    Stalker stalker;
    Tanky tanky;
    WeakMinion weakMinion;
    MiniBoss miniboss;

    public Coroutine fieldDamageCoroutine; // fieldTriggerHandler ýn alanýna girdiginde calisan coroutine buna atanir.
    public Coroutine orbitDamageCoroutine;

    public TextMeshProUGUI damageText;

    bool isTextCoroutineActive;

    private void Awake()
    {
        if (GetComponent<Stalker>() != null)
        {
            stalker = GetComponent<Stalker>();

            thisHealth = stalker.health;
            thisDamage = stalker.damage;
            thisAttackSpeed = stalker.attackSpeed;
            thisGoldReward = stalker.goldReward;
            thisScoreReward = stalker.scoreReward;
            
        }
        else if (GetComponent<Tanky>() != null)
        {
            tanky = GetComponent<Tanky>();

            thisHealth = tanky.health;
            thisDamage = tanky.damage;
            thisAttackSpeed = tanky.attackSpeed;
            thisGoldReward = tanky.goldReward;
            thisScoreReward = tanky.scoreReward;

        }
        else if (GetComponent<WeakMinion>() != null)
        {
            weakMinion = GetComponent<WeakMinion>();

            thisHealth = weakMinion.health;
            thisDamage = weakMinion.damage;
            thisAttackSpeed = weakMinion.attackSpeed;
            thisGoldReward = weakMinion.goldReward;
            thisScoreReward = weakMinion.scoreReward;

        }
        else if (GetComponent<MiniBoss>() != null)
        {
            miniboss = GetComponent<MiniBoss>();

            thisHealth = miniboss.health;
            thisDamage = miniboss.damage;
            thisAttackSpeed = miniboss.attackSpeed;
            thisGoldReward = miniboss.goldReward;
            thisScoreReward = miniboss.scoreReward;

        }
        damageAnim = GetComponentInChildren<Animator>();

    }
    private void Start()
    {
        playerCollisionHandler = FindObjectOfType<PlayerCollisionHandler>();
        playerData = FindObjectOfType<PlayerData>();
        loot = GetComponent<Loot>();
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null && this.enabled)
            {
                damageCoroutine = StartCoroutine(DealDamage(damageable));
            }
            
            
        }
        
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Particle"))
        {
            TakeDamage((int)MineData.Instance.damage);
        }
    }
   
    IEnumerator DealDamage(IDamageable damageable)
    {
        if (damageable != null)
        {
            while (true)
            {
                if (damageable != null)
                {
                    damageable.TakeDamage(thisDamage);
                                       
                }
               

                yield return new WaitForSeconds(thisAttackSpeed);
            }
        }
        
        
    }
    public void StopDamageCoroutines() 
    {
        StopCoroutine(damageCoroutine);
    }
       
    IEnumerator DamageTextPopup(int amount)
    {
        
        isTextCoroutineActive = true;

        damageText.gameObject.SetActive(true);
        damageAnim.SetTrigger("PopupAnim");



        damageText.text = amount.ToString();
        yield return new WaitForSeconds(0.3f);
        damageText.gameObject.SetActive(false);
        isTextCoroutineActive = false;

            
    }
    public void OnDamageTaken(int amount)
    {
        if (!isTextCoroutineActive)
        {
            StartCoroutine(DamageTextPopup(amount));

        }

        thisHealth -= amount;
        
        if (thisHealth <= 0 )
        {
            StopAllCoroutines();
            Bank.Instance.IncreaseGold(thisGoldReward);
            UiManager.Instance.UpdateScoreAmount();
            PlayerData.Instance.score += thisScoreReward;
            playerCollisionHandler.damageDealers.Remove(this);
            SpawnManager.Instance.aliveEnemyCount--;
            loot.CheckItemChance(this.transform.position);
            gameObject.SetActive(false);
            
            
            
             //Destroy(gameObject);
            //UiManager.Instance.SetHealthFillRate();

        }
    }


    // ---------------- INTERFACES ---------------- //
    public void TakeDamage(int amount) // interface
    {
        if (thisHealth > 0)
        {
            OnDamageTaken(amount);
        }
    }


}
