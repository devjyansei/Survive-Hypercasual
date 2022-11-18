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
            //�arpma efekti. yerde k�sa s�reli iz. belki lerp ile opacitysi 0a d���r�lebilir.
        }
    }
}
