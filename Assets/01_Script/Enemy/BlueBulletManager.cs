using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlueBulletManager : MonoBehaviour
{


    public GameObject Bullet;
    private Transform poolManagertransform = null;
    [SerializeField] private BlueBullet BDir;
    [SerializeField] private GameObject SpriteName;
    void Start()
    {
        poolManagertransform = FindObjectOfType<BluePullManager>().GetComponent<Transform>();
        StartCoroutine("EnableBullet");
    }

    bool JimballBoom =false;

    IEnumerator EnableBullet()
    {
        while (true)
        {
            GameObject obj = null;
            if (SpriteName.name == "CrazyBirdSprite")
            {
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
                    BDir.SetDir(j, 3, 0);
                    obj.transform.position = transform.position;
                }
            }
            else if (SpriteName.name == "JimballSprite" && JimballBoom == false)
            {
                JimballBoom = true;
                yield return new WaitForSeconds(4f);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
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
                        BDir.SetDir(j, 2, 1);
                        obj.transform.position = transform.position;
                    }
                    yield return new WaitForSeconds(1f);
                }
                JimballBoom = false;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
