using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffChoseManagement : MonoBehaviour
{

    public static BuffChoseManagement Instance;
    
    public List<GameObject> buffList = new List<GameObject>();

    public GameManager gameManager;

    public GameObject orbit;
    public GameObject bullet;
    public GameObject mine;
    public GameObject field;

    public GameObject orbitButton;
    public GameObject bulletButton;
    public GameObject mineButton;
    public GameObject fieldButton;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }

        buffList.Add(orbit);
        buffList.Add(bullet);
        buffList.Add(mine);
        buffList.Add(field);
    }

    // ONSELECTED FUNCTIONS
    public void OrbitSelected()
    {
        foreach (GameObject buff in buffList)
        {
            buff.SetActive(false);
        }

        orbitButton.SetActive(false);
        orbit.SetActive(true);
        buffList.Remove(orbit);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();
    }

    public void BulletSelected()
    {

        foreach (GameObject buff in buffList)
        {
            buff.SetActive(false);
        }

        bulletButton.SetActive(false);
        bullet.SetActive(true);
        buffList.Remove(bullet);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();

    }

    public void MineSelected()
    {
        foreach (GameObject buff in buffList)
        {
            mine.SetActive(false);
        }

        mineButton.SetActive(false);
        mine.SetActive(true);
        buffList.Remove(mine);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();

    }
    public void FieldSelected()
    {
        foreach (GameObject buff in buffList)
        {
            field.SetActive(false);
        }

        fieldButton.SetActive(false);
        field.SetActive(true);
        buffList.Remove(field);
        UiManager.Instance.choseOneCanvas.SetActive(false);
        gameManager.StartGame();

    }

    // ONCOLLECTED FUNCTIONS
    public void OrbitCollected()
    {
        

        orbit.gameObject.SetActive(true);
        buffList.Remove(orbit);
    }
    public void BulletCollected()
    {
        

        bullet.gameObject.SetActive(true);
        buffList.Remove(bullet);
    }
    public void MineCollected()
    {
        

        mine.gameObject.SetActive(true);
        buffList.Remove(mine);
    }
    public void FieldCollected()
    {
        

        field.gameObject.SetActive(true);
        buffList.Remove(field);
    }
}

