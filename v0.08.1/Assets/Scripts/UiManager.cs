using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    private void Awake()
    {
        Instance = this;
    }

 
}
