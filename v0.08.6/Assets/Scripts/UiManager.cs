using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    //UPGRADE CANVAS
    public GameObject buttonPanel;
    public GameObject menuPanel;
    public GameObject upgradePanel;
    public GameObject closeButtonpPanel;
    public GameObject openButtonPanel;

    //START CANVAS
    public GameObject startMenuCanvas;
    public TextMeshProUGUI highscoreText;
    //GAMEVOVER PANEL
    public GameObject gameOverCanvas;
    //CHOSE ONE CANVAS
    public GameObject choseOneCanvas;

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
        SetHealthFillRate();
    }
   public void OpenChoseOneCanvas()
    {
        startMenuCanvas.SetActive(false);
        openButtonPanel.SetActive(true);
        choseOneCanvas.SetActive(true);
    }
    public void CloseStartCanvas()
    {
        startMenuCanvas.SetActive(false);
        openButtonPanel.SetActive(true);
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
    public void CloseUpgradeCanvas()
    {
        buttonPanel.SetActive(false);
        menuPanel.SetActive(false);
        upgradePanel.SetActive(false);
        closeButtonpPanel.SetActive(false);
        openButtonPanel.SetActive(true);
        inGameGold.gameObject.SetActive(true);
        inGameScore.gameObject.SetActive(true);
    }
    public void OpenUpgradeCanvas()
    {
        buttonPanel.SetActive(true);
        menuPanel.SetActive(true);
        upgradePanel.SetActive(true);
        closeButtonpPanel.SetActive(true);
        openButtonPanel.SetActive(false);
        inGameGold.gameObject.SetActive(false);
        inGameScore.gameObject.SetActive(false);
    }
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
