using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffChoseManagement : MonoBehaviour
{

    
    
    public List<GameObject> dropList = new List<GameObject>();

    public GameManager gameManager;


    public GameObject orbit;
    public GameObject bullet;
    public GameObject mine;
    private void Awake()
    {
        dropList.Add(orbit);
        dropList.Add(bullet);
        dropList.Add(mine);
    }

    public void OrbitSelected()
    {
        foreach (GameObject buff in dropList)
        {
            buff.SetActive(false);
        }
        orbit.SetActive(true);
        dropList.Remove(orbit);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();
    }

    public void BulletSelected()
    {

        foreach (GameObject buff in dropList)
        {
            buff.SetActive(false);
        }
        bullet.SetActive(true);
        dropList.Remove(bullet);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();

    }

    public void MineSelected()
    {
        foreach (GameObject buff in dropList)
        {
            mine.SetActive(false);
        }
        mine.SetActive(true);
        dropList.Remove(mine);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();

    }


}

