using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance=null)
        {
            Instance = this;
        }                  
    }

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        Time.timeScale = 0;    
        UiManager.Instance.OpenStartCanvas();

    }
    public void Prepare()
    {
        UiManager.Instance.OpenChoseOneCanvas();
        UiManager.Instance.CloseStartCanvas();

    }
    public void StartGame()
    {
        Time.timeScale = 1f;

        Debug.Log("Game Started");

       // UiManager.Instance.CloseGameoverPanel();
    }


    public void GameOver()
    {

        Time.timeScale = 0f;
        UiManager.Instance.OpenGameoverCanvas();
        CheckScore();
        //reklam cýkart.

    }
    public void ResetAllStates()
    {
        SceneManager.LoadScene(0);
    }

    void CheckScore()
    {
        if (PlayerData.Instance.score > Save.Instance.highscore)
        {
            Save.Instance.highscore = PlayerData.Instance.score;
            PlayerPrefs.SetInt("Highscore", PlayerData.Instance.score);            
        }
    }

    public void yazdir()
    {
        Debug.Log("void");
    }


    // reklam butonu mapte arada belirecek.


}
