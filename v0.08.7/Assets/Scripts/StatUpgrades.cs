using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatUpgrades : MonoBehaviour
{
    public HypercasualMovement hypercasualMovement;

    public static StatUpgrades Instance;

    [Header("LEVELS")]
    public int healthLevel;
    public int defenceLevel;
    public int speedLevel;

    [Header("UPGRADE COSTS")]
    public int healthUpgradeCost;
    public int defenceUpgradeCost;
    public int speedUpgradeCost;

    [Header("COST RAISES")]
    public int healthUpgradeCostRaise;
    public int defenceUpgradeCostRaise;
    public int speedUpgradeCostRaise;

    [Header("IMAGES")]
    public Image[] healthImages;
    public Image[] defenceImages;
    public Image[] speedImages;

    [Header("COST TEXTS")]
    public TextMeshProUGUI healthCostText;
    public TextMeshProUGUI defenceCostText;
    public TextMeshProUGUI speedCostText;

    [Header("MENU")]
    public TextMeshProUGUI statsGoldAmountText;

    private void Awake()
    {
        Instance = this;


    }
    private void Start()
    {
        UiManager.Instance.UpdateGoldAmount();
        statsGoldAmountText.text = Bank.Instance.goldAmount.ToString();

        healthCostText.text = healthUpgradeCost.ToString();
        defenceCostText.text = defenceUpgradeCost.ToString();
        speedCostText.text = speedUpgradeCost.ToString();

    }
    public void UpgradeHealth()
    {
        if (Bank.Instance.goldAmount > healthUpgradeCost  &&  healthLevel < healthImages.Length)
        {
            Bank.Instance.goldAmount -= healthUpgradeCost;
            UiManager.Instance.UpdateGoldAmount();
            statsGoldAmountText.text = Bank.Instance.goldAmount.ToString();

            for (int i = 0; i <= healthLevel; i++)
            {
                healthImages[i].color = Color.green;
            }
            healthLevel++;

            healthUpgradeCost += healthUpgradeCostRaise;
            healthCostText.text = healthUpgradeCost.ToString();

            PlayerData.Instance.maxHealth += 20f;

            PlayerPrefs.SetInt("HealthLevel", healthLevel);
            PlayerPrefs.SetInt("HealthCost", healthUpgradeCost);
        }
    }
    public void UpgradeDefence()
    {
        if (Bank.Instance.goldAmount > defenceUpgradeCost && defenceLevel < defenceImages.Length)
        {
            Bank.Instance.goldAmount -= defenceUpgradeCost;
            UiManager.Instance.UpdateGoldAmount();
            statsGoldAmountText.text = Bank.Instance.goldAmount.ToString();

            for (int i = 0; i <= defenceLevel; i++)
            {
                defenceImages[i].color = Color.green;
            }
            defenceLevel++;

            defenceUpgradeCost += defenceUpgradeCostRaise;
            defenceCostText.text = defenceUpgradeCost.ToString();


            PlayerData.Instance.defence++;

            PlayerPrefs.SetInt("DefenceLevel", defenceLevel);
            PlayerPrefs.SetInt("DefenceCost", defenceUpgradeCost);
        }
    }
    public void UpgradeSpeed()
    {
        if (Bank.Instance.goldAmount > speedUpgradeCost  &&  speedLevel < speedImages.Length)
        {
            Bank.Instance.goldAmount -= speedUpgradeCost;
            UiManager.Instance.UpdateGoldAmount();
            statsGoldAmountText.text = Bank.Instance.goldAmount.ToString();

            for (int i = 0; i <= speedLevel; i++)
            {
                speedImages[i].color = Color.green;
            }
            speedLevel++;

            speedUpgradeCost += speedUpgradeCostRaise;
            speedCostText.text = speedUpgradeCost.ToString();


            hypercasualMovement.speed += 0.2f;


            PlayerPrefs.SetInt("SpeedLevel", speedLevel);
            PlayerPrefs.SetInt("SpeedCost", speedUpgradeCost);

        }
    }
}
