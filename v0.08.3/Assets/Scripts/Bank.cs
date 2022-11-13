using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance;

    public int goldAmount;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UiManager.Instance.UpdateGoldAmount();
    }
    public void IncreaseGold(int amount)
    {
        goldAmount += amount;
        UiManager.Instance.UpdateGoldAmount();
    }
    public void DecreaseGold(int amount)
    {
        goldAmount -= amount;
        UiManager.Instance.UpdateGoldAmount();
    }





}
