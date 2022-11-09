using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    BulletMovement bulletMovement;

    public GameObject bulletPrefab;
    public GameObject spawnPosition;
    GameObject target;
    public float speed = 1f;
    private void Awake()
    {
        bulletMovement = FindObjectOfType<BulletMovement>();
    }
    private void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            StartCoroutine(SendMissile(tempBullet));

        }
        */
    }
    IEnumerator SendMissile(GameObject bullet)
    {
        while (true)
        {
          /*  if (tempBullet != null )
            {
                GameObject tempBullet = Instantiate(bulletPrefab);
                tempBullet.transform.position += (bulletMovement.closestTarget.transform.position - tempBullet.transform.position).normalized * speed * Time.deltaTime;
                tempBullet.transform.LookAt(bulletMovement.closestTarget.transform);
               // Debug.Log(Vector3.Distance(target.transform.position, tempBullet.transform.position));

            }
          */



          /* if (Vector3.Distance(bulletMovement.closestTarget.transform.position, tempBullet.transform.position) < 0.1f)
            {
                Debug.Log("fggfh");
                //  tempBullet.SetActive(false);
                tempBullet = null;

                Destroy(tempBullet);
 
            }
          */
            yield return null;
        }
    }




}
