using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public Image orbitAmountUpg;
    private void Awake()
    {
        Instance = this;
    }

    public void FillOrbitAmountUpgrade()
    {
        orbitAmountUpg.color = Color.red;
    }

}
