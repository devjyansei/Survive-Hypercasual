using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SelfDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
