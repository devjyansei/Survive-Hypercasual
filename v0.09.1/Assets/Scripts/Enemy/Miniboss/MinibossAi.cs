using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MinibossAi : MonoBehaviour
{
    DistanceController distanceController;
    
    private void Awake()
    {
        distanceController = GetComponent<DistanceController>();
    }
    IEnumerator Lasergun()
    {
        while (this.gameObject.transform != null)
        {
            Debug.Log("faz1");
            this.transform.GetChild(0).gameObject.SetActive(true);
            transform.DORotate(new Vector3(0, 72000, 0), 2000f, RotateMode.LocalAxisAdd); // bug var. 
            yield return new WaitForSeconds(10f);
            Debug.Log("corutin bitti");

        }
        //distanceController.enabled = true;
        //distanceController.targetFollow.enabled = true;

    }
    public void StartLasergun()
    {
        StartCoroutine(Lasergun());

    }
}
