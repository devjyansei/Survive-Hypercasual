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

        OrbitData.Instance.orbitAmount = 1;
        OrbitData.Instance.SetOrbitAmount();

        UiManager.Instance.CloseStartCanvas();
        UiManager.Instance.CloseGameoverPanel();


        SpawnManager.Instance.StartEnemyGenerator();
        SpawnManager.Instance.StartFirstWave();

        Time.timeScale = 1f;

    }

    public void StopGame()
    {
        Time.timeScale = 0;
        UiManager.Instance.OpenUpgradeCanvas();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        UiManager.Instance.CloseUpgradeCanvas();
    }


    public void GameOver()
    {

        Time.timeScale = 0f;
        UiManager.Instance.OpenGameoverCanvas();
        //Open Gameover panel
        //reklam c�kart.

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
        // Tum bufflari s�f�rla.
        // marketi s�f�rla
        //player statlar�n� s�f�rla
    }









    // reklam butonu arada belirecek.


    // oyun a��ld�g�nda sadece menu canvas a��k olacak. m�zik �alacak. highscore g�runecek.
    // 

}
