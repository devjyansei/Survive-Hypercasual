using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    //UPGRADE CANVAS
    public GameObject upgradesButtonPanel;
    public GameObject upgradesMenuPanel;
    public GameObject upgradesUpgradePanel;
    public GameObject upgradesCloseButtonpPanel;
    public GameObject upgradesOpenButtonPanel;

    //STATS CANVAS
    public GameObject statsButtonPanel;
    public GameObject statsMenuPanel;
    public GameObject statsUpgradePanel;
    public GameObject statsCloseButtonPanel;
    public GameObject statsOpenButtonPanel;

    //START CANVAS
    public GameObject startMenuCanvas;
    public TextMeshProUGUI highscoreText;
    //GAMEVOVER PANEL
    public GameObject gameOverCanvas;
    //CHOSE ONE CANVAS
    public GameObject choseOneCanvas;

    //texts
    public TextMeshProUGUI goldAmountText;
    public TextMeshProUGUI inGameScore;
    public TextMeshProUGUI inGameGold;
    

    // Animations
    public Animator scoreGainAnim;

    // player health
    public Image playerHealthImage;


    private void Awake()
    {
        Instance = this;

        
    }
   
    private void Update()
    {
        inGameGold.text = "Gold : " + Bank.Instance.goldAmount.ToString();
        inGameScore.text = "Score : " + PlayerData.Instance.score;
        StatUpgrades.Instance.statsGoldAmountText.text = "Gold : " + Bank.Instance.goldAmount.ToString();
        SetHealthFillRate();
    }
   public void OpenChoseOneCanvas()
    {
        startMenuCanvas.SetActive(false);
        upgradesOpenButtonPanel.SetActive(true);
        choseOneCanvas.SetActive(true);
        Time.timeScale = 0;
    }

   
    public void CloseStartCanvas()
    {
        startMenuCanvas.SetActive(false);
        upgradesOpenButtonPanel.SetActive(true);
    }
    public void OpenStartCanvas()
    {
        startMenuCanvas.SetActive(true);
    }

    public void CloseGameoverPanel()
    {
        gameOverCanvas.SetActive(false);
    }
    public void OpenGameoverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }



    // STATS CANVAS
    public void OpenStatsCanvas()
    {
        statsButtonPanel.SetActive(true);
        statsMenuPanel.SetActive(true);
        statsUpgradePanel.SetActive(true);
        statsCloseButtonPanel.SetActive(true);
        statsOpenButtonPanel.SetActive(false);

        inGameGold.gameObject.SetActive(false);
        inGameScore.gameObject.SetActive(false);

        upgradesOpenButtonPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void CloseStatsCanvas()
    {
        statsButtonPanel.SetActive(false);
        statsMenuPanel.SetActive(false);
        statsUpgradePanel.SetActive(false);
        statsCloseButtonPanel.SetActive(false);
        statsOpenButtonPanel.SetActive(true);

        inGameGold.gameObject.SetActive(true);
        inGameScore.gameObject.SetActive(true);

        upgradesOpenButtonPanel.SetActive(true);
        Time.timeScale = 1;
    }




    // UPGRADE CANVAS
    public void OpenUpgradeCanvas()
    {
        upgradesButtonPanel.SetActive(true);
        upgradesMenuPanel.SetActive(true);
        upgradesUpgradePanel.SetActive(true);
        upgradesCloseButtonpPanel.SetActive(true);
        upgradesOpenButtonPanel.SetActive(false);
        inGameGold.gameObject.SetActive(false);
        inGameScore.gameObject.SetActive(false);



        statsOpenButtonPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseUpgradeCanvas()
    {
        upgradesButtonPanel.SetActive(false);
        upgradesMenuPanel.SetActive(false);
        upgradesUpgradePanel.SetActive(false);
        upgradesCloseButtonpPanel.SetActive(false);
        upgradesOpenButtonPanel.SetActive(true);
        inGameGold.gameObject.SetActive(true);
        inGameScore.gameObject.SetActive(true);


        statsOpenButtonPanel.SetActive(true);
        Time.timeScale = 1;

    }


   






    // SCORE & HEALTH FILL & GOLD
    public void UpdateGoldAmount()
    {
        goldAmountText.text = "GOLD : " + Bank.Instance.goldAmount.ToString();

    }
    public void UpdateScoreAmount()
    {
        inGameScore.text = "SCORE : " + PlayerData.Instance.score;
        scoreGainAnim.SetTrigger("ScoreTrigger");
    }
    public void SetHealthFillRate()
    {
        playerHealthImage.fillAmount = PlayerData.Instance.health / PlayerData.Instance.maxHealth;
    }
}
