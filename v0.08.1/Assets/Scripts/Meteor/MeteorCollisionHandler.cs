using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(MeteorData.Instance.damage);    
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //çarpma efekti. yerde kýsa süreli iz. belki lerp ile opacitysi 0a düþürülebilir.
        }
    }
}
