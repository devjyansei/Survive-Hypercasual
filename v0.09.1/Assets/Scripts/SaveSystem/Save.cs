using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save Instance;

    public int highscore;
    public int highestScore;

    public UiManager uiManager;
    public StatUpgrades statUpgrades;
    public PlayerData playerData;
    public HypercasualMovement hypercasualMovement;
    private void Awake()
    {
        Instance = this;

        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
            highscore = PlayerPrefs.GetInt("Highscore");
            uiManager.highscoreText.text = "HIGHSCORE : " + highscore.ToString();
        }
        else
        {
            highscore = PlayerPrefs.GetInt("Highscore");
            uiManager.highscoreText.text = "HIGHSCORE : " + highscore.ToString();
        }


        //health level
        if (!PlayerPrefs.HasKey("HealthLevel"))
        {
            PlayerPrefs.SetInt("HealthLevel", 0);
            statUpgrades.healthLevel = PlayerPrefs.GetInt("HealthLevel");
        }
        else
        {
            statUpgrades.healthLevel = PlayerPrefs.GetInt("HealthLevel");

            for (int i = 0; i < statUpgrades.healthLevel; i++)
            {
                statUpgrades.healthImages[i].color = Color.green;
            }
            playerData.maxHealth += statUpgrades.healthLevel * 20;
            playerData.health = playerData.maxHealth;

        }
        //health cost
        if (!PlayerPrefs.HasKey("HealthCost"))
        {
            PlayerPrefs.SetInt("HealthCost", statUpgrades.healthUpgradeCost);

        }
        else
        {
            statUpgrades.healthUpgradeCost = PlayerPrefs.GetInt("HealthCost");

        }

        // defence level
        if (!PlayerPrefs.HasKey("DefenceLevel"))
        {
            PlayerPrefs.SetInt("DefenceLevel", 0);
            statUpgrades.defenceLevel = PlayerPrefs.GetInt("DefenceLevel");

        }
        else
        {
            statUpgrades.defenceLevel = PlayerPrefs.GetInt("DefenceLevel");

            for (int i = 0; i < statUpgrades.defenceLevel; i++)
            {
                statUpgrades.defenceImages[i].color = Color.green;
            }
            playerData.defence = statUpgrades.defenceLevel;

        }
        //defence cost
        if (!PlayerPrefs.HasKey("DefenceCost"))
        {
            PlayerPrefs.SetInt("DefenceCost", statUpgrades.defenceUpgradeCost);

        }
        else
        {
            statUpgrades.defenceUpgradeCost = PlayerPrefs.GetInt("DefenceCost");

        }
        // speed level
        if (!PlayerPrefs.HasKey("SpeedLevel"))
        {
            PlayerPrefs.SetInt("SpeedLevel", 0);
            statUpgrades.speedLevel = PlayerPrefs.GetInt("SpeedLevel");

        }
        else
        {
            statUpgrades.speedLevel = PlayerPrefs.GetInt("SpeedLevel");

            for (int i = 0; i < statUpgrades.speedLevel; i++)
            {
                statUpgrades.speedImages[i].color = Color.green;
            }

            hypercasualMovement.speed += statUpgrades.speedLevel * 0.2f;
        }
        //speed cost
        if (!PlayerPrefs.HasKey("SpeedCost"))
        {
            PlayerPrefs.SetInt("SpeedCost", statUpgrades.speedUpgradeCost);

        }
        else
        {
            statUpgrades.speedUpgradeCost = PlayerPrefs.GetInt("SpeedCost");

        }
    }




    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highestScore = highscore;
    }



}
