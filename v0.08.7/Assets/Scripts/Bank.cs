using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    public int goldAmount;
    public Animator goldGainAnim;


    private void Awake()
    {
        Instance = this;
    }
    /*private void Start()
    {
        UiManager.Instance.UpdateGoldAmount();
    }*/
    public void IncreaseGold(int amount)
    {
        goldAmount += amount;
        UiManager.Instance.UpdateGoldAmount();
        goldGainAnim.SetTrigger("GoldTrigger");

    }
    public void DecreaseGold(int amount)
    {
        goldAmount -= amount;
        UiManager.Instance.UpdateGoldAmount();
    }





}
