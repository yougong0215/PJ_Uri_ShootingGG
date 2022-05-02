using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlueBulletManager : MonoBehaviour
{


    public GameObject Bullet;
    private Transform poolManagertransform = null;
    [SerializeField] private BlueBullet BDir;
    private SpriteRenderer SpriteName;
    void Start()
    {
        SpriteName = gameObject.GetComponent<SpriteRenderer>();
        poolManagertransform = FindObjectOfType<BluePullManager>().GetComponent<Transform>();
        StartCoroutine("EnableBullet");
    }
    IEnumerator EnableBullet()
    {
        while (true)
        {
            if (SpriteName.sprite.name == "CrazyBird")
            {
                GameObject obj = null;
                for (int j = 0; j < 3; j++)
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

                    BDir = obj.gameObject.GetComponent<BlueBullet>();
                    BDir.SetDir(j);
                    obj.transform.position = transform.position;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    
}
