using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public GameObject buttonPanel;
    public GameObject menuPanel;
    public GameObject upgradePanel;
    public GameObject closeButtonpPanel;
    public GameObject openButtonpPanel;


    public TextMeshProUGUI goldAmountText;

    private void Awake()
    {
        Instance = this;
    }

    public void CloseCanvas()
    {
        buttonPanel.SetActive(false);
        menuPanel.SetActive(false);
        upgradePanel.SetActive(false);
        closeButtonpPanel.SetActive(false);
        openButtonpPanel.SetActive(true);
    }
    public void OpenCanvas()
    {
        buttonPanel.SetActive(true);
        menuPanel.SetActive(true);
        upgradePanel.SetActive(true);
        closeButtonpPanel.SetActive(true);
        openButtonpPanel.SetActive(false);
    }
    public void UpdateGoldAmount()
    {
        goldAmountText.text = "GOLD : " + Bank.Instance.goldAmount.ToString();
    }
}
