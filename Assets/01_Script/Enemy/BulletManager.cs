using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletManager : MonoBehaviour
{

    public GameObject Bullet;
    private Transform poolManagertransform = null;
    [SerializeField] private BulletTrans BDir;
    [SerializeField] private GameObject SpriteName;
    void Start()
    {
        poolManagertransform = FindObjectOfType<BluePullManager>().GetComponent<Transform>();
        
    }

    public void EnableBullet()
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
        BDir = obj.gameObject.GetComponent<BulletTrans>();

        BDir.SetObj(gameObject, obj.gameObject);

        obj.transform.position = transform.position;
        

    }
}


