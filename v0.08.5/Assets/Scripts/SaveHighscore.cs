using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighscore : MonoBehaviour
{
    public static SaveHighscore Instance;

    public int highscore;
    public int highestScore;

    public UiManager uiManager;

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
    }
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highestScore = highscore;
    }



}
