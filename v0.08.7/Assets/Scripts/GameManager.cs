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
        
       // ResetAllStates();
    }
    public void StartGame()
    {
       // ResetAllStates();

        //OrbitData.Instance.orbitAmount = 1;
        //OrbitData.Instance.SetOrbitAmount();

        UiManager.Instance.CloseStartCanvas();
        UiManager.Instance.CloseGameoverPanel();
        Time.timeScale = 1f;



        //SpawnManager.Instance.CreateFirstWaveEnemys();

        //MissileAuto.Instance.StartCreateMissile();

    }

    public void StopGame()
    {

    }
    public void ResumeGame()
    {

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




        /*
        PlayerData.Instance.transform.position = PlayerData.Instance.startPos;

        EnemyCollisionHandler[] enemys = FindObjectsOfType<EnemyCollisionHandler>();
        foreach (EnemyCollisionHandler enemy in enemys)
        {          
            Destroy(enemy.gameObject);
        }

        PlayerData.Instance.health = 100;

        FieldTriggerHandler.Instance.tempDamageCoroutine = null;

        FieldTriggerHandler.Instance.StopAllCoroutines();
        */
        //Bank.Instance.goldAmount = 0;
        // Tum bufflari sýfýrla.
        // marketi sýfýrla
        //player statlarýný sýfýrla
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
