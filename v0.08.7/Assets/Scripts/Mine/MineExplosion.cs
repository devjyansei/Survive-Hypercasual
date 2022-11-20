using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public ParticleSystem explosionParticle;


    private void OnEnable()
    {
        BoxCollider bc = transform.GetChild(0).GetComponent<BoxCollider>(); 
        bc.size *= MineData.Instance.explosionRadius; // set explosion radius

        GetComponent<MeshRenderer>().enabled = true;
        explosionParticle.gameObject.SetActive(false);
        StartCoroutine(ExplodeMine());
    }


    IEnumerator ExplodeMine()
    {
        yield return new WaitForSeconds(MineData.Instance.detonateDelay);
        explosionParticle.gameObject.SetActive(true);
        explosionParticle.Play();
    }
}
