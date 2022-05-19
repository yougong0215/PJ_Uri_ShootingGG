using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMaster : MonoBehaviour
{
    public GameObject Bullet;
    private Transform poolManagertransform = null;

    void Start()
    {
        poolManagertransform = FindObjectOfType<PoolManager>().GetComponent<Transform>();
        StartCoroutine("EnableBullet");
    }
    IEnumerator EnableBullet()
    {
        GameObject obj = null;
        while (true)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                if (poolManagertransform.childCount > 0)
            {
                obj = poolManagertransform.GetChild(0).gameObject;
                obj.SetActive(true);
            }
            else
            {
                obj = Instantiate(Bullet, transform);
            }
                obj.transform.SetParent(null);
                obj.transform.position = transform.position;
            }
           


            yield return new WaitForSeconds(0.05f);
        }
    }

}
