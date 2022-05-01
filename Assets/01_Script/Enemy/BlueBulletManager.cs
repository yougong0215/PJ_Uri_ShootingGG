using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlueBulletManager : MonoBehaviour
{

    public static int blueDir = 0;

    public GameObject Bullet;
    private Transform poolManagertransform = null;
    [SerializeField] private BlueBullet BDir;
    void Start()
    {
        poolManagertransform = FindObjectOfType<BluePullManager>().GetComponent<Transform>();
        StartCoroutine("EnableBullet");
    }
    IEnumerator EnableBullet()
    {
        GameObject obj = null;

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
           
            yield return new WaitForEndOfFrame();
        blueDir++;
        StartCoroutine("EnableBullet");
    }
    
}
